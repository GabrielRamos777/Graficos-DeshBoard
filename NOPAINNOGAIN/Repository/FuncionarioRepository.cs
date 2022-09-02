
using Microsoft.EntityFrameworkCore;
using NOPAINNOGAIN.Interfaces;
using NOPAINNOGAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOPAINNOGAIN.Data.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {

        public FuncionarioRepository(ApplicationDbContext context) : base(context)
        {
                
        }

        public async Task<Funcionario> ObterFuncionarioEndereco(Guid id)
        {
            return await Db.FuncionariosGR.AsNoTracking().Include(f => f.Endereco)
                .FirstOrDefaultAsync(e => e.ID == id);
        }
    }
}
