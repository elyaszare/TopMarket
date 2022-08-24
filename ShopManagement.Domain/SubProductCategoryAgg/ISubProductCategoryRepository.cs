using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.SubProductCategory;

namespace ShopManagement.Domain.SubProductCategoryAgg
{
    public interface ISubProductCategoryRepository : IRepository<long, SubProductCategory>
    {
        EditSubProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> GetProductCategories();
        List<SubProductCategoryViewModel> GetSubProductCategories();
        ProductCategoryViewModel GetSlugBy(long id);
        SubProductCategory GetSubCategoryWithCategorySlugBy(long id);
        List<SubProductCategoryViewModel> Search(SubProductCategorySearchModel searchModel);
    }
}
