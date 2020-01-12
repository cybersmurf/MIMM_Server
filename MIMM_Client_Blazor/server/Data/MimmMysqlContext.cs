using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using MimmClientBlazor.Models.MimmMysql;

namespace MimmClientBlazor.Data
{
  public partial class MimmMysqlContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public MimmMysqlContext(DbContextOptions<MimmMysqlContext> options):base(options)
    {
    }

    public MimmMysqlContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<MimmClientBlazor.Models.MimmMysql.Song>()
              .HasOne(i => i.Track)
              .WithMany(i => i.Songs)
              .HasForeignKey(i => i.idtracks)
              .HasPrincipalKey(i => i.id);

        builder.Entity<MimmClientBlazor.Models.MimmMysql.Song>()
              .Property(p => p.idtracks)
              .HasDefaultValueSql("0");

        builder.Entity<MimmClientBlazor.Models.MimmMysql.Song>()
              .Property(p => p.whispertime)
              .HasDefaultValueSql("CURRENT_TIMESTAMP");


        this.OnModelBuilding(builder);
    }


    public DbSet<MimmClientBlazor.Models.MimmMysql.Album> Albums
    {
      get;
      set;
    }

    public DbSet<MimmClientBlazor.Models.MimmMysql.Artist> Artists
    {
      get;
      set;
    }

    public DbSet<MimmClientBlazor.Models.MimmMysql.Feeling> Feelings
    {
      get;
      set;
    }

    public DbSet<MimmClientBlazor.Models.MimmMysql.Song> Songs
    {
      get;
      set;
    }

    public DbSet<MimmClientBlazor.Models.MimmMysql.Track> Tracks
    {
      get;
      set;
    }

    public DbSet<MimmClientBlazor.Models.MimmMysql.User> Users
    {
      get;
      set;
    }
  }
}
