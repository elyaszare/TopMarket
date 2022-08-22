using _0_Framework;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Domain.SubProductCategory
{
    public class SubProductCategory : EntityBase
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
        public long CategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public SubProductCategory(string name, string picture, string pictureAlt, string pictureTitle,
            string shortDescription, string description, string keywords, string metaDescription, string slug,
            long categoryId)
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
            CategoryId = categoryId;
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle,
            string shortDescription, string description, string keywords, string metaDescription, string slug,
            long categoryId)
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
            CategoryId = categoryId;
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
