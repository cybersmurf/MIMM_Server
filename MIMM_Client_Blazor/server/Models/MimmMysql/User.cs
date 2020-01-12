using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MimmClientBlazor.Models.MimmMysql
{
  [Table("users")]
  public partial class User
  {
    [Key]
    public string email
    {
      get;
      set;
    }
    public int id
    {
      get;
      set;
    }
    public string firstname
    {
      get;
      set;
    }
    public string lastname
    {
      get;
      set;
    }
    public string password
    {
      get;
      set;
    }
  }
}
