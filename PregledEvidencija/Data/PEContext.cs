using Microsoft.EntityFrameworkCore;
using PregledEvidencija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregledEvidencija.Data
{
    public class PEContext : DbContext
    {
            public PEContext(DbContextOptions<PEContext> options) : base(options)
            {
            }

            public DbSet<Proizvod> Proizvods { get; set; }
            public DbSet<InspekcijskaKontrola> InspekcijskaKontrolas { get; set; }
            public DbSet<InspekcijskoTijelo> InspekcijskoTijelos { get; set; }        
    
}
}
