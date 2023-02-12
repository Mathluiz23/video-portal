using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace video_portal.Models
{
  public class Comment
  {
    public int CommentId { get; set; }

    public string CommentText { get; set; } = default!;

    public int VideoId { get; set; }

    public Video Video { get; set; } = default!;

    public int UserId { get; set; }

    public User User { get; set; } = default!;

  }
}
