using System.Collections.Generic;
using ShopManagement.Application.Contracts.SubProductCategory;

namespace ShopManagement.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Picture { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public string Category { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }
        public List<SubProductCategoryViewModel> SubCategories { get; set; }
    }
}