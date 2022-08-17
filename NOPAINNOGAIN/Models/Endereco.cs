using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NOPAINNOGAIN.Models
{
    public class Endereco : Entity
    {
        public Guid FuncionarioId { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O Campo {0} deve ter entre {2} e {1}", MinimumLength = 2)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O Campo {0} deve ter entre {2} e {1}", MinimumLength = 2)]
        public string Numero { get; set; }
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(9, ErrorMessage = "O Campo {0} deve ter entre {2} e {1}", MinimumLength = 8)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O Campo {0} deve ter entre {2} e {1}", MinimumLength = 2)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O Campo {0} deve ter entre {2} e {1}", MinimumLength = 2)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O Campo {0} deve ter entre {2} e {1}", MinimumLength = 2)]
        public string Estado { get; set; }

        public Funcionario Funcionario { get; set; }
    }
}
