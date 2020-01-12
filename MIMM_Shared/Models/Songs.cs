using System;
using System.Collections.Generic;

namespace MIMM_Shared.Models
{
    public partial class Songs
    {
        public int Id { get; set; }
        public DateTime Whispertime { get; set; }
        public int Idtracks { get; set; }
        public int Idfeeling { get; set; }

        public virtual Tracks IdtracksNavigation { get; set; }
    }
}
