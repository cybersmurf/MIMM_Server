using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MimmClientBlazor.Models.MimmMysql
{
  [Table("feelings")]
  public partial class Feeling
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id
    {
      get;
      set;
    }
    public string name
    {
      get;
      set;
    }
  }
}
