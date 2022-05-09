using System;
using System.Collections.Generic;

namespace WypozyczalniaAplikacjaWebowa.Models
{
    public partial class HistoriaUzytkownika
    {
        public string NazwaUzytkownikaHistoria { get; set; } = null!;
        public int IloscWykonanychPrzejazdow { get; set; }
        public float LacznaIloscPrzejechanychKm { get; set; }
        public TimeSpan LacznyCzasWypozyczaniaSprzetu { get; set; }
        public decimal LacznaKwotaWydanaNaWypozyczenia { get; set; }

        public virtual Uzytkownicy NazwaUzytkownikaHistoriaNavigation { get; set; } = null!;
    }
}
