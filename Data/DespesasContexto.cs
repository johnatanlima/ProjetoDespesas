using Microsoft.EntityFrameworkCore;
using ProjetoDespesas.Models;
using ProjetoDespesas.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDespesas.Data
{
    public class DespesasContexto : DbContext
    {
        public DespesasContexto(DbContextOptions<DespesasContexto> options) : base (options)
        {
        }

        public DbSet<TipoDespesa> TipoDespesas {get; set;}
        public DbSet<Despesa> Despesas {get; set;}
        public DbSet<Salario> Salarios {get; set;}
        public DbSet<Mes> Meses {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoDespesaMap());
            modelBuilder.ApplyConfiguration(new DespesaMap());
            modelBuilder.ApplyConfiguration(new MesMap());
            modelBuilder.ApplyConfiguration(new SalarioMap());
            
        }
    }
}
