using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProfileImageDomain
    {
        public int? UserId { get; set; }
        public Stream? Image { get; set; }
        public string? FileName { get; set; }
    }
}
