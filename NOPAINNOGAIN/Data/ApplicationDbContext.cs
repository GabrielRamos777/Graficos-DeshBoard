using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NOPAINNOGAIN.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOPAINNOGAIN.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> FuncionariosGR { get; set; }
        public DbSet<Endereco> EnderecosGR { get; set; }
        public DbSet<MedGrupo> MedGrupoGR { get; set; }
        public DbSet<Usuario> UsuariosGR { get; set; }
        public DbSet<Comentario> ComentariosGR { get; set; }
        public DbSet<Logado> LogadosGR { get; set; }
        public DbSet<Aparelho> AparelhosGR { get; set; }
    }
}
