using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MimmClientBlazor.Models.MimmMysql
{
  [Table("tracks")]
  public partial class Track
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id
    {
      get;
      set;
    }


    public ICollection<Song> Songs { get; set; }
    public string name
    {
      get;
      set;
    }
  }
}
