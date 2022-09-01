using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NOPAINNOGAIN.Models
{
    public class Aparelho : Entity
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [Display(Name = "Grupo Muscular")]
        public string Grupomuscular { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [Display(Name = "Preço")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [Display(Name = "Data do produto (Início)")]
        public DateTime Tempo { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [Display(Name = "Data do produto (Fim)")]
        public DateTime tempoFim { get; set; }
    }
}
