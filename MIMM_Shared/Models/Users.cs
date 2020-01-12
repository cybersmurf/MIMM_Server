using System;
using System.Collections.Generic;

namespace MIMM_Shared.Models
{
    public partial class Users
    {
        public uint Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
