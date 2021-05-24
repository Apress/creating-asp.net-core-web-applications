using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoStore.Core;

namespace VideoStore.Data
{
    public class SQLData : IVideoData
    {
        private readonly VideoDbContext _database;

        public SQLData(VideoDbContext database) => _database = database;

        public Video AddVideo(Video newVideo)
        {
            _ = _database.Add(newVideo);
            return newVideo;
        }

        public Video GetVideo(int id) => _database.Videos.Find(id);

        public Video GetTopVideo()
        {
            var rnd = new Random();
            if (_database.Videos.Count() == 0)
                return new Video();
            else
            {
                var r = rnd.Next(1, _database.Videos.Count());
                return _database.Videos.Find(r);
            }            
        }

        public IEnumerable<Video> ListVideos(string title) => _database.Videos
                .Where(x => string.IsNullOrEmpty(title)
                || x.Title.StartsWith(title))
                .OrderBy(x => x.Title);

        public int Save() => _database.SaveChanges();

        public Video UpdateVideo(Video videoData)
        {
            var entity = _database.Videos.Attach(videoData);
            entity.State = EntityState.Modified;
            return videoData;
        }
    }
}
