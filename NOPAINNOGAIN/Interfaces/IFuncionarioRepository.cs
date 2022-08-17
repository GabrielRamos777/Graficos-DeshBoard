
using NOPAINNOGAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOPAINNOGAIN.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
         
        Task<Funcionario> ObterFuncionarioEndereco(Guid id);
    }
}
