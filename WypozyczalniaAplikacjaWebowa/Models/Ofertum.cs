using System;
using System.Collections.Generic;

namespace WypozyczalniaAplikacjaWebowa.Models
{
    public partial class Ofertum
    {
        public Ofertum()
        {
            Wypozyczenia = new HashSet<Wypozyczenium>();
        }

        public int IdOfertyPrzejazdu { get; set; }
        public decimal KosztPrzejazdu { get; set; }
        public DateTime CzasPrzejazdu { get; set; }

        public virtual ICollection<Wypozyczenium> Wypozyczenia { get; set; }
    }
}
