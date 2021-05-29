using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Models;

namespace TCC.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AgendaCastramovel> AgendasCastramovel { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<ClinicaEndereco> ClinicaEnderecos { get; set; }
        public DbSet<Denuncia> Denuncias { get; set; }
        public DbSet<DenunciaEndereco> DenunciasEnderecos { get; set; }
        public DbSet<UsuarioEndereco> UsuariosEnderecos { get; set; }
        public DbSet<Horarios> Horarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Usuario>().HasIndex(u => u.Cpf).IsUnique();
            builder.Entity<Usuario>().HasIndex(u => u.Rg).IsUnique();
            builder.Entity<Usuario>().HasIndex(u => u.UserName).IsUnique(false);
            builder.Entity<Usuario>().HasIndex(u => u.NormalizedUserName).IsUnique(false);

        }
    }
}
