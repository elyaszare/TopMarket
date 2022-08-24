using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<SlideViewModel> GetSlides()
        {
            return _context.Slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Text = x.Text,
                BtnLink = x.BtnLink,
                BtnText = x.BtnText,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                CreationDate = x.CreationDate.ToFarsi(),
                Picture = x.Picture,
                IsRemoved = x.IsRemoved
            }).OrderByDescending(x => x.Id).ToList();
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                Title = x.Title,
                Text = x.Text,
                BtnLink = x.BtnLink,
                BtnText = x.BtnText,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
