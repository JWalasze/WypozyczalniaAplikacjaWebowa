using System;
using System.Collections.Generic;

namespace WypozyczalniaAplikacjaWebowa.Models
{
    public partial class HistoriaWypozyczen
    {
        public int IdWypozyczenia { get; set; }
        public DateTime? DataRozpoczeciaWypozyczenia { get; set; }
        public DateTime? DataZakonczeniaWypozyczenia { get; set; }
        public DateTime? CzasTrwaniaWypozyczenia { get; set; }
        public float? PrzejechanyDystans { get; set; }
        public bool CzyPrzejazdOplacony { get; set; }
        public decimal? KosztPrzejazdu { get; set; }

        public virtual Wypozyczenium IdWypozyczeniaNavigation { get; set; } = null!;
    }
}
