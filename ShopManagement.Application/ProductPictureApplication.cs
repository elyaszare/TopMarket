using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IFileUploader fileUploader,
            IProductRepository productRepository)
        {
            _productPictureRepository = productPictureRepository;
            _fileUploader = fileUploader;
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            var getSlug = _productRepository.GetProductWithSlugBy(command.ProductId);

            var filePath =
                $"{getSlug.SubCategory.ProductCategory.Slug}/{getSlug.SubCategory.Slug}/{getSlug.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, filePath);

            var picture = new ProductPicture(fileName, command.PictureAlt, command.PictureTitle, command.ProductId);

            _productPictureRepository.Create(picture);
            _productPictureRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.GetProductWithSlugBy(command.Id);

            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var filePath =
                $"{productPicture.Product.SubCategory.ProductCategory.Slug}/{productPicture.Product.SubCategory.Slug}/{productPicture.Product.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, filePath);

            productPicture.Edit(fileName, command.PictureAlt, command.PictureTitle, command.ProductId);

            _productPictureRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);

            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            productPicture.Remove();

            _productPictureRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);

            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            productPicture.Restore();

            _productPictureRepository.SaveChanges();
            return operation.Success();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public List<ProductPictureViewModel> GetProductPictures()
        {
            return _productPictureRepository.GetProductPictures();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }
}
