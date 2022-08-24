namespace ShopManagement.Application.Contracts.Slide
{
    public class SlideViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string BtnText { get; set; }
        public bool IsRemoved { get; set; }
        public string BtnLink { get; set; }
        public string CreationDate { get; set; }
    }
}