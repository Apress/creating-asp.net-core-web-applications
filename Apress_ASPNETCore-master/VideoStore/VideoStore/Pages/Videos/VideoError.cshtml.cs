using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace VideoStore.Pages.Videos
{
    public class VideoErrorModel : PageModel
    {
        private readonly ILogger<VideoErrorModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }

        public VideoErrorModel(ILogger<VideoErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogError(Message);
        }
    }
}