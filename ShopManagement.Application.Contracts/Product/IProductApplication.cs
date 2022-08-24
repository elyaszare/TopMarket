using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.SubProductCategory;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        EditProduct GetDetails(long id);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        List<SubProductCategoryViewModel> GetSubProductCategories();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        List<ProductViewModel> GetProducts();
    }
}
