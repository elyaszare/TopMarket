using _0_Framework;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : EntityBase
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }
        public string Slug { get; set; }
        public bool IsRemoved { get; set; }

        public ArticleCategory(string name, string picture, string pictureAlt, string pictureTitle, string description,
            string metaDescription, string keywords, string slug)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            MetaDescription = metaDescription;
            Keywords = keywords;
            Slug = slug;
            IsRemoved = false;
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle, string description,
            string metaDescription, string keywords, string slug)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            MetaDescription = metaDescription;
            Keywords = keywords;
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
