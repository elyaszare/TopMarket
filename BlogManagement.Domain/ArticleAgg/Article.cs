namespace BlogManagement.Domain.ArticleAgg
{
    public class Article
    {
        public string Title { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public bool IsRemoved { get; set; }
    }
}
