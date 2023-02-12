using video_portal.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;


namespace video_portal.Repository

{
  public class VideoPortalRepository : IVideoPortalRepository
  {
    private readonly IVideoPortalContext _context;
    public VideoPortalRepository(IVideoPortalContext context)
    {
      _context = context;
    }
    public Video GetVideoById(int videoId)
    {
      Video video = _context.Videos
        .AsNoTracking()
        .Where(video => video.VideoId == videoId)
        .FirstOrDefault();

      return video!;
    }
    public IEnumerable<Video> GetVideos()
    {
      List<Video> videos = _context.Videos
        .ToList();

      return videos;
    }
    public Channel GetChannelById(int channelId)
    {
      Channel channel = _context.Channels
        .AsNoTracking()
        .Where(channel => channel.ChannelId == channelId)
        .FirstOrDefault();

      return channel!;
    }
    public IEnumerable<Channel> GetChannels()
    {
      List<Channel> channels = _context.Channels
        .ToList();

      return channels;
    }
    public IEnumerable<Video> GetVideosByChannelId(int channelId)
    {
      List<Video> videos = _context.Videos
        .Where(video => video.ChannelId == channelId)
        .ToList();

      return videos;

    }
    public IEnumerable<Comment> GetCommentsByVideoId(int videoId)
    {
      List<Comment> comments = _context.Comments
        .Where(comment => comment.VideoId == videoId)
        .ToList();

      return comments;
    }
    public void DeleteChannel(Channel channel)
    {
      if (channel.Videos?.Count > 0)
      {
        throw new InvalidOperationException();
      }
      _context.Channels.RemoveRange(channel);
      _context.SaveChanges();
    }
    public void AddVideoToChannel(Channel channel, Video video)
    {
      Video videoFoundById = GetVideoById(video.VideoId);
      videoFoundById.ChannelId = channel.ChannelId;
      _context.Videos.Update(videoFoundById);
      _context.SaveChanges();
    }
  }
}
