using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PregledEvidencija.Models
{
    public class Proizvod
    {
            public int ID { get; set; }
            [DisplayName("Naziv")]
            public string Naziv { get; set; }
            [DisplayName("Proizvođač")]
            public string Proizvodjac { get; set; }
            [DisplayName("Serijski broj")]
            public string SerijskiBroj { get; set; }
            [DisplayName("Zemlja porijekla")]
            public string ZemljaPorijekla { get; set; }
            [DisplayName("Opis proizvoda")]
            public string Opis { get; set; }

        

    }
}
