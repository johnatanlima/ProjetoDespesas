namespace ProjetoDespesas.Models
{
    public class TipoDespesa
    {
        public int TipoDesepesaId { get; set; }

        
        public string Nome { get; set; }

        public ICollection<Despesa> Despesas {get; set;}
    }
}