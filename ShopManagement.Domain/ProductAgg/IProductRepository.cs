using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.SubProductCategory;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long, Product>
    {
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        string GetSlugBy(long id);
        List<SubProductCategoryViewModel> GetSubProductCategories();
        List<ProductViewModel> GetProducts();
    }
}
