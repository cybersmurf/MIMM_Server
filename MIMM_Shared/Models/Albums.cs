using System;
using System.Collections.Generic;

namespace MIMM_Shared.Models
{
    public partial class Albums
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Idartist { get; set; }
    }
}
