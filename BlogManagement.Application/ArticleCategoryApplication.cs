using System.Collections.Generic;
using _0_Framework.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository,
            IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operation = new OperationResult();

            if (_articleCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicateRecord);

            var filePath = $"Blog/{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, filePath);

            var slug = command.Slug.Slugify();

            var articleCategory = new ArticleCategory(command.Name, fileName, command.PictureAlt, command.PictureTitle,
                command.Description, command.MetaDescription, command.Keywords, slug);

            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(command.Id);

            if (articleCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_articleCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicateRecord);

            var filePath = $"Blog/{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, filePath);

            var slug = command.Slug.Slugify();

            articleCategory.Edit(command.Name, fileName, command.PictureAlt, command.PictureTitle,
                command.Description, command.MetaDescription, command.Keywords, slug);

            _articleCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(id);

            if (articleCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            articleCategory.Remove();

            _articleCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(id);

            if (articleCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            articleCategory.Restore();

            _articleCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _articleCategoryRepository.GetArticleCategories();
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return _articleCategoryRepository.Search(searchModel);
        }
    }
}
