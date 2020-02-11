using Microsoft.EntityFrameworkCore;
using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerParcial.DAL.Scripts
{
   public class Context : DbContext
    {
        
        public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server = DESKTOP-P8O7KNF\SQLEXPRESS; Database = ProductosDb; Trusted_Connection = True; ");

        }

    }
}
