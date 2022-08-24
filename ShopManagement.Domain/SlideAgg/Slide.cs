using _0_Framework;

namespace ShopManagement.Domain.SlideAgg
{
    public class Slide : EntityBase
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string BtnText { get; set; }
        public string BtnLink { get; set; }
        public bool IsRemoved { get; set; }

        public Slide(string title, string text, string picture, string pictureAlt, string pictureTitle, string btnText,
            string btnLink)
        {
            Title = title;
            Text = text;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            BtnText = btnText;
            BtnLink = btnLink;
            IsRemoved = false;
        }

        public void Edit(string title, string text, string picture, string pictureAlt, string pictureTitle,
            string btnText, string btnLink)
        {
            Title = title;
            Text = text;
            if (picture != null)
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            BtnText = btnText;
            BtnLink = btnLink;
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
