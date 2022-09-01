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

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<MedGrupo> MedGrupo { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Logado> Logados { get; set; }
        public DbSet<Aparelho> Aparelhos { get; set; }
    }
}
