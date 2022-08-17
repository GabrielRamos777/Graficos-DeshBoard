using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOPAINNOGAIN.Models
{
    public class Funcionario : Entity
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O Campo {0} deve ter entre {2} e {1}", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O Campo {0} deve ter entre {2} e {1}", MinimumLength = 11)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O Campo {0} deve ter entre {2} e {1}", MinimumLength = 2)]
        public string Imagem { get; set; }
        [NotMapped]
        [DisplayName("Foto")]
        public IFormFile ImagemUpload { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [DisplayName("Tipo do Funcionario")]
        public TipoFuncionario TipoFuncionario { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public double Salario { get; set; }

        #region RelacionamentoEndereco
        public Endereco Endereco { get; set; }
        #endregion




    }
}
