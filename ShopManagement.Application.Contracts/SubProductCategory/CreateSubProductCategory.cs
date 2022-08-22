using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Application.Contracts.SubProductCategory
{
    public class CreateSubProductCategory
    {
        public string Name { get; set; }
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public long CategoryId { get; set; }
        public List<ProductCategoryViewModel> ProductCategories { get; set; }
    }
}
