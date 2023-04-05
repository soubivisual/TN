using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TN.Modules.Buildings.Shared.Persistance;
using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Loggers.Domain.ApplicationLogs.Aggregates;
using TN.Modules.Loggers.Domain.TraceLogs.Aggregates;
using TN.Modules.Loggers.Domain.UserActivities.Aggregates;

namespace TN.Modules.Loggers.Infrastructure.DataAccess
{
    internal class LoggersDbContext : DbContext
    {
        internal DbSet<ApplicationLog> ApplicationLogs { get; set; }

        internal DbSet<TraceLog> TraceLogs { get; set; }

        internal DbSet<UserActivity> UserActivities { get; set; }

        private readonly string _schemaName;

        public LoggersDbContext(DbContextOptions<LoggersDbContext> options) : base(options)
        {
            _schemaName = this.GetType().Name.Replace(nameof(DbContext), string.Empty);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString(ConnectionStrings.Database), y => y.MigrationsHistoryTable("MigrationsHistory", _schemaName));
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>().HaveColumnType("varchar");
            configurationBuilder.Properties<ValueObjectBase<string>>().HaveColumnType("varchar");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(_schemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
