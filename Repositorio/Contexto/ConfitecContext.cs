using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repositorio.Contexto
{
    public class ConfitecContext : DbContext
    {
        private readonly string _connectionString;
        public ConfitecContext(DbContextOptions<ConfitecContext> options) : base(options)
        {

        }
        public ConfitecContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
