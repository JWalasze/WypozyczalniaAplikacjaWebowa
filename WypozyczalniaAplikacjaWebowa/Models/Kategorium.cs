using System;
using System.Collections.Generic;

namespace WypozyczalniaAplikacjaWebowa.Models
{
    public partial class Kategorium
    {
        public Kategorium()
        {
            Pojazds = new HashSet<Pojazd>();
        }

        public int IdKategorii { get; set; }
        public string NazwaKategorii { get; set; } = null!;

        public virtual ICollection<Pojazd> Pojazds { get; set; }
    }
}
