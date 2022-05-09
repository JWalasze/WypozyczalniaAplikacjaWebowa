using System;
using System.Collections.Generic;

namespace WypozyczalniaAplikacjaWebowa.Models
{
    public partial class Pojazd
    {
        public int IdKategoriiPojazdu { get; set; }
        public int IdPojazdu { get; set; }
        public string Status { get; set; } = null!;
        public string Usterki { get; set; } = null!;

        public virtual Kategorium IdKategoriiPojazduNavigation { get; set; } = null!;
        public virtual Mapa Mapa { get; set; } = null!;
    }
}
