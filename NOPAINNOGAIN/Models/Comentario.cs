using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NOPAINNOGAIN.Models
{
    public class Comentario : Entity
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Comentarios { get; set; }
    }
}
