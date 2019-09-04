using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDespesas.Models
{
    public class TipoDespesa
    {
        public int TipoDespesaId { get; set; }

        [StringLength(50, ErrorMessage="Use menos caracteres.")]
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public string Nome { get; set; }

        public ICollection<Despesa> Despesas {get; set;}
    }
}