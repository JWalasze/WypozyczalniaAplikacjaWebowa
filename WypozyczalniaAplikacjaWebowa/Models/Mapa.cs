using System;
using System.Collections.Generic;

namespace WypozyczalniaAplikacjaWebowa.Models
{
    public partial class Mapa
    {
        public string LokalizacjaGpsPojazdu { get; set; } = null!;
        public string StatusPojazdu { get; set; } = null!;
        public string Miasto { get; set; } = null!;
        public int IdPojazduWMiescie { get; set; }

        public virtual Pojazd IdPojazduWMiescieNavigation { get; set; } = null!;
        public virtual Wypozyczenium Wypozyczenium { get; set; } = null!;
    }
}
