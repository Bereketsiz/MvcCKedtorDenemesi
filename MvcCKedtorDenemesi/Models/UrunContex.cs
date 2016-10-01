using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcCKedtorDenemesi.Models
{
    public class UrunContex : DbContext 
    {
        public DbSet<Urun> Uruns { get; set; }

    }
}