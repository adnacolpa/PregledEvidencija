using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PregledEvidencija.Models
{
    public class InspekcijskaKontrola
    {
        public int ID { get; set; }
        [DisplayName("Datum kontrole")]
        public DateTime DatumKontrole { get; set; }
        [DisplayName("Nadležno tijelo")]
        public virtual InspekcijskoTijelo NadleznoTijelo { get; set; }
        [DisplayName("Kontrolisani proizvod")]
        public virtual Proizvod KontrolisaniProizvod { get; set; }
        [DisplayName("Rezultati  kontrole")]
        public string RezultatiKontrole { get; set; }
        [DisplayName("Da li je proizvood siguran?")]
        public Boolean ProizvodSiguran { get; set; }
    }
}
