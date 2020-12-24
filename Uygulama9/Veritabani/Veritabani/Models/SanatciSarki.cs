using System;
using System.Collections.Generic;

#nullable disable

namespace Veritabani.Models
{
    public partial class SanatciSarki
    {
        public int Id { get; set; }
        public int SarkiId { get; set; }
        public int SanatciId { get; set; }

        public virtual Sanatci Sanatci { get; set; }
        public virtual Sarki Sarki { get; set; }
    }
}
