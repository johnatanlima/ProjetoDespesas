using System.ComponentModel.DataAnnotations;

namespace ProjetoDespesas.Models
{
    public class Salario
    {
        public int SalarioId { get; set; }

        public int MesId { get; set; }
        public Mes Mes {get; set;}

        [Required(ErrorMessage="Campo Obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage="Valor Inválido.")]
        public double Valor {get; set;}
    }
}