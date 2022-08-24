using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.SubProductCategory;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;

        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();

            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicateRecord);

            var filePath = $"{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, filePath);

            var slug = command.Slug.Slugify();

            var product = new Product(command.Name, command.Code, fileName, command.PictureAlt,
                command.PictureTitle, command.ShortDescription, command.Description, command.MetaDescription,
                command.Keywords, slug, command.CategoryId);

            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.Id);

            if (product == null) return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicateRecord);

            var filePath = $"{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, filePath);

            var slug = command.Slug.Slugify();

            product.Edit(command.Name, command.Code, fileName, command.PictureAlt,
                command.PictureTitle, command.ShortDescription, command.Description, command.MetaDescription,
                command.Keywords, slug, command.CategoryId);

            _productRepository.SaveChanges();
            return operation.Success();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);

            if (product == null) return operation.Failed(ApplicationMessages.RecordNotFound);

            product.Remove();

            _productRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);

            if (product == null) return operation.Failed(ApplicationMessages.RecordNotFound);

            product.Restore();

            _productRepository.SaveChanges();
            return operation.Success();
        }

        public List<SubProductCategoryViewModel> GetSubProductCategories()
        {
            return _productRepository.GetSubProductCategories();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}
