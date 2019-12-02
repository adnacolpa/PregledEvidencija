using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PregledEvidencija.Models
{
    public class InspekcijskoTijelo
    {  
        public int ID { get; set; }
        [DisplayName("Naziv")]
        public string Naziv { get; set; }
        [DisplayName("Inspektorat")]
        public string Inspektorat { get; set; }
        [DisplayName("Nadležnost")]
        public string Nadleznost { get; set; }
        [DisplayName("Kontakt osoba")]
        public string KontaktOsoba { get; set; }
    }
}
