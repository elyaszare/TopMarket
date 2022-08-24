using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IFileUploader _fileUploader;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();

            if (_slideRepository.Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicateRecord);

            var filePath = $"Slides/{command.Title}";
            var fileName = _fileUploader.Upload(command.Picture, filePath);

            var slide = new Slide(command.Title, command.Text, fileName, command.PictureAlt, command.PictureTitle,
                command.BtnText, command.BtnLink);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(command.Id);
            if (slide is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var filePath = $"Slides/{command.Title}";
            var fileName = _fileUploader.Upload(command.Picture, filePath);

            slide.Edit(command.Title, command.Text, fileName, command.PictureAlt, command.PictureTitle,
                command.BtnText, command.BtnLink);
            _slideRepository.SaveChanges();
            return operation.Success();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Remove();
            _slideRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide is null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Restore();
            _slideRepository.SaveChanges();
            return operation.Success();
        }

        public List<SlideViewModel> GetSlides()
        {
            return _slideRepository.GetSlides();
        }
    }
}
