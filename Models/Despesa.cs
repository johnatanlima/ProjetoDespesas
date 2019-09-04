using System.ComponentModel.DataAnnotations;

namespace ProjetoDespesas.Models
{
    public class Despesa
    {
        public int DespesaId { get; set; }

        public int MesId { get; set; }
        public Mes Mes {get; set;}

        public int TipoDespesaId {get; set;}

        [Required(ErrorMessage="Use menos caracteres.")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor Inválido.")]
        public double Valor {get; set;}
    }
}