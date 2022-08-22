using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.SubProductCategory;

namespace ShopManagement.Domain.SubProductCategory
{
    public interface ISubProductCategoryRepository : IRepository<long, SubProductCategory>
    {
        EditSubProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> GetProductCategories();
        List<SubProductCategoryViewModel> GetSubProductCategories();
        List<SubProductCategoryViewModel> Search(SubProductCategorySearchModel searchModel);
    }
}
