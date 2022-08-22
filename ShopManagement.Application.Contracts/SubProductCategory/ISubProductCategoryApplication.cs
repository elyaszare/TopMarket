using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Application.Contracts.SubProductCategory
{
   public interface ISubProductCategoryApplication
    {
        OperationResult Create(CreateSubProductCategory command);
        OperationResult Edit(EditSubProductCategory command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        List<ProductCategoryViewModel> GetProductCategories();
        EditSubProductCategory GetDetails(long id);
        List<SubProductCategoryViewModel> GetSubProductCategories();
        List<SubProductCategoryViewModel> Search(SubProductCategorySearchModel searchModel);
    }
}
