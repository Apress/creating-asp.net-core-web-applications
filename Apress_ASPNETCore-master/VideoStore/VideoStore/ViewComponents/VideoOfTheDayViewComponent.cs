using Microsoft.AspNetCore.Mvc;
using VideoStore.Data;

namespace VideoStore.ViewComponents
{
    public class VideoOfTheDayViewComponent : ViewComponent
    {
        private readonly IVideoData _videoData;

        public VideoOfTheDayViewComponent(IVideoData videoData)
        {
            _videoData = videoData;
        }

        public IViewComponentResult Invoke()
        {
            var video = _videoData.GetTopVideo();
            return View(video);
        }
    }
}