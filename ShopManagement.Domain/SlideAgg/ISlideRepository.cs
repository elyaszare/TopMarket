using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Slide;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<long, Slide>
    {
        List<SlideViewModel> GetSlides();
        EditSlide GetDetails(long id);
    }
}
