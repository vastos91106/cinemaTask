using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class EFContext : DbContext
    {
        public EFContext() :
            base(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\igor\documents\visual studio 2015\Projects\Cinema\Web\App_Data\DB.mdf;Integrated Security=True"
            )
        {
        }

        public virtual DbSet<Film> Films { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}