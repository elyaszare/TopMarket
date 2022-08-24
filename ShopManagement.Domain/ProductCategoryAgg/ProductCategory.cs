using System.Collections.Generic;
using _0_Framework;
using ShopManagement.Domain.SubProductCategoryAgg;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public bool IsRemoved { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public List<SubProductCategory> SubProductCategories { get; set; }

        public ProductCategory(string name, string picture, string pictureAlt, string pictureTitle,
            string shortDescription, string description, string keywords, string metaDescription, string slug)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Description = description;
            IsRemoved = false;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle,
            string shortDescription, string description, string keywords, string metaDescription, string slug)
        {
            Name = name;
            if (picture != null) Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Description = description;
            IsRemoved = false;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
