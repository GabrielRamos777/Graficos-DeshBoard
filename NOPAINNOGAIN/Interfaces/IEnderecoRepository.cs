
using NOPAINNOGAIN.Interfaces;
using NOPAINNOGAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOPAINNOGAIN.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFuncionario(Guid funcioanrioId);
    }
}
