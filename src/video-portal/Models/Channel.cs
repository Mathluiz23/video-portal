using System.ComponentModel.DataAnnotations;

namespace video_portal.Models
{
  public class Channel
  {
    public int ChannelId { get; set; }
    public string ChannelName { get; set; } = default!;

    public string? ChannelDescription { get; set; }

    public string Url { get; set; } = default!;

    public ICollection<Video> Videos { get; set; } = default!;

    public ICollection<User> Owners { get; set; } = default!;
  }
}
