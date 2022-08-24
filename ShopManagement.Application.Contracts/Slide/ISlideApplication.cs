using System.Collections.Generic;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        EditSlide GetDetails(long id);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        List<SlideViewModel> GetSlides();
    }
}
