using PregledEvidencija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregledEvidencija.Data
{
    public class DBInitializer
    {
        public static void Initialize(PEContext context)
        {
            if (context.Proizvods.Any())
            {
                return;
            }

            
            Proizvod[] proizvodi = new Proizvod[]
            {

                new Proizvod{Naziv="proizvod1",Opis="opis1", Proizvodjac="pro1", SerijskiBroj="432432", ZemljaPorijekla="Bosna i Hercegovina"},
                new Proizvod{Naziv="proizvod2",Opis="opis2", Proizvodjac="pro2", SerijskiBroj="432432", ZemljaPorijekla="Srbija"},
                new Proizvod{Naziv="proizvod3",Opis="opis3", Proizvodjac="pro3", SerijskiBroj="432432", ZemljaPorijekla="Makedonija"}
            };

            context.Proizvods.AddRange(proizvodi);
            context.SaveChanges();
        }
    }
}
