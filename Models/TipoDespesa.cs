using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoDespesas.Models
{
    public class TipoDespesa
    {
        public int TipoDespesaId { get; set; }

        [StringLength(50, ErrorMessage="Use menos caracteres.")]
        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Remote("verificaDespesa", "TipoDespesa")]
        public string Nome { get; set; }

        public ICollection<Despesa> Despesas {get; set;}
    }
}