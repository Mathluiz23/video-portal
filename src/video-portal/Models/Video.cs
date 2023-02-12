using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace video_portal.Models
{
  public class Video
  {
    public int VideoId { get; set; }

    public string Title { get; set; } = default!;

    public string? Description { get; set; }

    public string Url { get; set; } = default!;

    public int? ChannelId { get; set; }

    public Channel Channel { get; set; } = default!;

    public ICollection<Comment> Comments { get; set; } = default!;
  }
}
