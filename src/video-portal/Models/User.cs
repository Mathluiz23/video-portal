using System.ComponentModel.DataAnnotations;

namespace video_portal.Models
{
  public class User
  {
    public int UserId { get; set; }

    public string Username { get; set; } = default!;

    public string Email { get; set; } = default!;

    public ICollection<Channel> Channels { get; set; } = default!;

    public ICollection<Comment> Comments { get; set; } = default!;

  }
}
