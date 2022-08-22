using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.SubProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.SubProductCategory
{
    public class IndexModel : PageModel
    {
        public SelectList ProductCategories;
        private readonly ISubProductCategoryApplication _subProductCategoryApplication;
        public List<SubProductCategoryViewModel> SubProductCategories;
        public SubProductCategorySearchModel SearchModel { get; set; }
        [TempData] public string Message { get; set; }

        public IndexModel(ISubProductCategoryApplication subProductCategoryApplication)
        {
            _subProductCategoryApplication = subProductCategoryApplication;
        }


        public void OnGet(SubProductCategorySearchModel searchModel)
        {
            ProductCategories = new SelectList(_subProductCategoryApplication.GetProductCategories(), "Id", "Name");
            SubProductCategories = _subProductCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateSubProductCategory
            {
                ProductCategories = _subProductCategoryApplication.GetProductCategories()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateSubProductCategory command)
        {
            var result = _subProductCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var subProductCategory = _subProductCategoryApplication.GetDetails(id);
            subProductCategory.ProductCategories = _subProductCategoryApplication.GetProductCategories();
            return Partial("./Edit", subProductCategory);
        }

        public JsonResult OnPostEdit(EditSubProductCategory command)
        {
            var result = _subProductCategoryApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _subProductCategoryApplication.Remove(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _subProductCategoryApplication.Restore(id);
            if (result.IsSucceeded) return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
