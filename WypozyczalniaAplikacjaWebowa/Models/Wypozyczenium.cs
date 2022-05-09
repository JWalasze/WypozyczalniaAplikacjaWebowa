using System;
using System.Collections.Generic;

namespace WypozyczalniaAplikacjaWebowa.Models
{
    public partial class Wypozyczenium
    {
        public string StatusWypozyczenia { get; set; } = null!;
        public int IdWypozyczenia { get; set; }
        public int IdOfertyPrzejazdu { get; set; }
        public string NazwaUzytkownikaWypozyczenia { get; set; } = null!;
        public int IdPojazduWypozyczenia { get; set; }

        public virtual Ofertum IdOfertyPrzejazduNavigation { get; set; } = null!;
        public virtual Mapa IdPojazduWypozyczeniaNavigation { get; set; } = null!;
        public virtual Uzytkownicy NazwaUzytkownikaWypozyczeniaNavigation { get; set; } = null!;
        public virtual HistoriaWypozyczen HistoriaWypozyczen { get; set; } = null!;
    }
}
