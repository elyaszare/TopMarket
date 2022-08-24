using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.SubProductCategory;
using ShopManagement.Domain.SubProductCategoryAgg;

namespace ShopManagement.Application
{
    public class SubProductCategoryApplication : ISubProductCategoryApplication
    {
        private readonly ISubProductCategoryRepository _subProductCategoryRepository;
        private readonly IFileUploader _fileUploader;
        public SubProductCategoryApplication(ISubProductCategoryRepository subProductCategoryRepository, IFileUploader fileUploader)
        {
            _subProductCategoryRepository = subProductCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSubProductCategory command)
        {
            var operation = new OperationResult();
            if (_subProductCategoryRepository.Exists(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.DuplicateRecord);
            }

            var categorySlug = _subProductCategoryRepository.GetSlugBy(command.CategoryId).Slug;
            var filePath = $"{categorySlug}//{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, filePath);
            var slug = command.Slug.Slugify();
            var subProductCategory = new SubProductCategory(command.Name, fileName, command.PictureAlt,
                command.PictureTitle, command.ShortDescription, command.Description, command.Keywords,
                command.MetaDescription, slug, command.CategoryId);
            _subProductCategoryRepository.Create(subProductCategory);
            _subProductCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditSubProductCategory command)
        {
            var operation = new OperationResult();
            var subProductCategory = _subProductCategoryRepository.GetSubCategoryWithCategorySlugBy(command.Id);

            if (subProductCategory is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_subProductCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicateRecord);
            var categorySlug = subProductCategory.ProductCategory.Slug;
            var filePath = $"{categorySlug}//{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, filePath);

            var slug = command.Slug.Slugify();

            subProductCategory.Edit(command.Name, fileName, command.PictureAlt,
                command.PictureTitle, command.ShortDescription, command.Description, command.Keywords,
                command.MetaDescription, slug, command.CategoryId);

            _subProductCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var subProductCategory = _subProductCategoryRepository.Get(id);

            if (subProductCategory is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            subProductCategory.Remove();

            _subProductCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var subProductCategory = _subProductCategoryRepository.Get(id);

            if (subProductCategory is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            subProductCategory.Restore();

            _subProductCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _subProductCategoryRepository.GetProductCategories();
        }

        public EditSubProductCategory GetDetails(long id)
        {
            return _subProductCategoryRepository.GetDetails(id);
        }

        public List<SubProductCategoryViewModel> GetSubProductCategories()
        {
            return _subProductCategoryRepository.GetSubProductCategories();
        }

        public List<SubProductCategoryViewModel> Search(SubProductCategorySearchModel searchModel)
        {
            return _subProductCategoryRepository.Search(searchModel);
        }
    }
}
