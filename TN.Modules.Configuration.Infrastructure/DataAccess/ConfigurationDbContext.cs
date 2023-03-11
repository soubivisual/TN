﻿using Microsoft.EntityFrameworkCore;
using TN.Modules.Configuration.Domain.Catalogs.Entities;

namespace TN.Modules.Configuration.Infrastructure.DataAccess
{
    internal class ConfigurationDbContext : DbContext
    {
        public DbSet<Catalog> Catalogs { get; set; }

        public ConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("configuration");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
