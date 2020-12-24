using System;
using System.Collections.Generic;

#nullable disable

namespace Veritabani.Models
{
    public partial class Sanatci
    {
        public Sanatci()
        {
            SanatciSarkis = new HashSet<SanatciSarki>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }

        public virtual ICollection<SanatciSarki> SanatciSarkis { get; set; }
    }
}
