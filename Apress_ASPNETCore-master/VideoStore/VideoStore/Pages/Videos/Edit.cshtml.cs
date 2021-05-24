using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Collections;
using VideoStore.Core;
using VideoStore.Data;
using System;

namespace VideoStore.Pages.Videos
{
    public class EditModel : PageModel
    {
        private readonly IVideoData _videoData;
        private readonly IHtmlHelper _helper;

        [BindProperty]
        public Video Video { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }

        public EditModel(IVideoData videoData, IHtmlHelper helper)
        {
            _videoData = videoData;
            _helper = helper;
        }

        public IActionResult OnGet(int? videoId)
        {
            Genres = _helper.GetEnumSelectList<MovieGenre>();
            Video = videoId.HasValue
                ? _videoData.GetVideo(videoId.Value)
                : new Video
                {
                    ReleaseDate = DateTime.Now.Date
                };

            return Video == null ? RedirectToPage("./VideoError", new { message = "The video does not exist" }) : (IActionResult)Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["CommitMessage"] = Video.Id > 0 ? "Video Updated" : "Video Added";
                _ = Video.Id > 0 ? _videoData.UpdateVideo(Video) : _videoData.AddVideo(Video);
                _ = _videoData.Save();
                
                return RedirectToPage("./Detail", new { videoId = Video.Id });
            }
            Genres = _helper.GetEnumSelectList<MovieGenre>();
            return Page();
        }
    }
}