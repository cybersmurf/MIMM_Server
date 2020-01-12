using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MimmClientBlazor.Models.MimmMysql
{
  [Table("songs")]
  public partial class Song
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id
    {
      get;
      set;
    }
    public int idtracks
    {
      get;
      set;
    }
    public Track Track { get; set; }
    public DateTime whispertime
    {
      get;
      set;
    }
  }
}
