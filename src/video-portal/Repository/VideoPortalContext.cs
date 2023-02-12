using Microsoft.EntityFrameworkCore;
using video_portal.Models;

namespace video_portal.Repository;

public class VideoPortalContext : DbContext, IVideoPortalContext
{
  public DbSet<Channel> Channels { get; set; }
  public DbSet<Video> Videos { get; set; }
  public DbSet<Comment> Comments { get; set; }
  public DbSet<User> Users { get; set; }
  public VideoPortalContext(DbContextOptions<VideoPortalContext> options) : base(options)
  {
    Channels = Set<Channel>();

    Videos = Set<Video>();

    Comments = Set<Comment>();

    Users = Set<User>();
  }
  public VideoPortalContext()
  {
    Channels = Set<Channel>();

    Videos = Set<Video>();

    Comments = Set<Comment>();

    Users = Set<User>();
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=master;User=SA;Password=Password12!;");
    }
  }
}
