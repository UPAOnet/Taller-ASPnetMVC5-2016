using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiPrimeraWebApp.Models
{
    public class MiPrimeraWebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MiPrimeraWebAppContext() : base("name=MiPrimeraWebAppContext")
        {
        }

        public System.Data.Entity.DbSet<MiPrimeraWebApp.Models.PaisModel> PaisModels { get; set; }

        public System.Data.Entity.DbSet<MiPrimeraWebApp.Models.EquipoModel> EquipoModels { get; set; }

        public System.Data.Entity.DbSet<MiPrimeraWebApp.Models.JugadorModel> JugadorModels { get; set; }
    }
}
