using System;
using System.Collections.Generic;

namespace MIMM_Shared.Models
{
    public partial class Tracks
    {
        public Tracks()
        {
            Songs = new HashSet<Songs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Idalbum { get; set; }

        public virtual ICollection<Songs> Songs { get; set; }
    }
}
