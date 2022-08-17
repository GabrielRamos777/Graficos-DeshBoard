
using Microsoft.EntityFrameworkCore;
using NOPAINNOGAIN.Business.Interfaces;
using NOPAINNOGAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOPAINNOGAIN.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<Endereco> ObterEnderecoPorFuncionario(Guid funcioanrioId)
        {
            return await Db.Enderecos.AsNoTracking().FirstOrDefaultAsync(f => f.FuncionarioId == funcioanrioId);
        }

      
    }
}
