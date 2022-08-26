using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductPicture;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long, ProductPicture>
    {
        ProductPicture GetProductWithSlugBy(long id);
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> GetProductPictures();
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
