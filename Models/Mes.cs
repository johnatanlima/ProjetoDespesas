using System.Collections.Generic;

namespace ProjetoDespesas.Models
{
    public class Mes
    {
        public int MesId { get; set; }

        public string Nome { get; set; }

        public ICollection<Despesa> Despesas {get; set;}

        public Salario Salario {get; set;}
    }
}