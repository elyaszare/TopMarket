
using System.Collections.Generic;
using _0_Framework;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SubProductCategoryAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public bool IsRemoved { get; private set; }
        public string MetaDescription { get; private set; }
        public string Keywords { get; private set; }
        public string Slug { get; private set; }
        public long CategoryId { get; private set; }
        public SubProductCategory SubCategory { get; set; }
        public List<ProductPicture> ProductPictures { get; set; }

        public Product(string name, string code, string picture, string pictureAlt, string pictureTitle,
            string shortDescription, string description, string metaDescription, string keywords, string slug,
            long categoryId)
        {
            Name = name;
            Code = code;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Description = description;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
            CategoryId = categoryId;
            IsRemoved = false;
        }


        public void Edit(string name, string code, string picture, string pictureAlt, string pictureTitle,
            string shortDescription, string description, string metaDescription, string keywords, string slug,
            long categoryId)
        {
            Name = name;
            Code = code;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Description = description;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
            CategoryId = categoryId;
            IsRemoved = false;
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
