using Microsoft.EntityFrameworkCore;
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
    }
}
