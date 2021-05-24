using System.Collections.Generic;
using VideoStore.Core;

namespace VideoStore.Data
{
    public interface IVideoData
    {
        IEnumerable<Video> ListVideos(string title);
        Video GetVideo(int id);
        Video GetTopVideo();
        Video UpdateVideo(Video videoData);
        Video AddVideo(Video newVideo);
        int Save();
    }
}
