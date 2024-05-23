using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contexts
{
    public class ContextoAplicacionDB : DbContext
    {
        public DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>().HasKey(p=>p.Id);
            base.OnModelCreating(modelBuilder);
        }

        public ContextoAplicacionDB(DbContextOptions<ContextoAplicacionDB> options) : base(options) { 
            
        }
    }
}
