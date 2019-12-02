using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PregledEvidencija.ViewModels
{
    public class InspekcijskaKontrolaViewModel
    {
        [DisplayName("Proizvod")]
        public int ProizvodID { get; set; }
        public IEnumerable<SelectListItem> ProizvodList { get; set; }
        [DisplayName("Nadležno tijelo")]
        public int NadleznoTijeloID { get; set; }
        public IEnumerable<SelectListItem> TijeloList { get; set; }
        public int ID { get; set; }
        [DisplayName("Datum kontrole")]
        public DateTime DatumKontrole { get; set; }

        [DisplayName("Rezultati kontrole")]
        public string RezultatiKontrole { get; set; }
        [DisplayName("Da li je proizvod siguran?")]
        public Boolean ProizvodSiguran { get; set; }
    }
}
