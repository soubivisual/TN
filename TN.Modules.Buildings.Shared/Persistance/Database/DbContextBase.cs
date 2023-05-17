using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using TN.Modules.Buildings.Shared.SharedKernel;

namespace TN.Modules.Buildings.Shared.Persistance.Database
{
    public class DbContextBase : DbContext
    {
        private ITenantInfo _tenant;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public string Schema { get; }

        public DbContextBase(DbContextOptions options, IMultiTenantContextAccessor multiTenantContextAccessor, IConfiguration configuration, IWebHostEnvironment env) : base(options) 
        {
            _tenant = multiTenantContextAccessor.MultiTenantContext?.TenantInfo;
            _configuration = configuration;
            _env = env;
        }

        public void SetCurrentTenant(ITenantInfo tenant)
        {
            _tenant = tenant;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString;
            var methodInfo = new StackTrace().GetFrame(1).GetMethod();
            var className = methodInfo.ReflectedType.Name;
            var schema = className.Replace(nameof(DbContext), string.Empty);

            if (_tenant is null && _env.IsDevelopment())
            {
                connectionString = _configuration.GetConnectionString(ConnectionStrings.Database);
            }
            else
            {
                connectionString = _tenant.ConnectionString;
            }

            optionsBuilder.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("__MigrationsHistory", schema));

#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging(true);
#endif
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

            var methodInfo = new StackTrace().GetFrame(1).GetMethod();
            var className = methodInfo.ReflectedType.Name;
            var schema = className.Replace(nameof(DbContext), string.Empty);

            modelBuilder.HasDefaultSchema(schema);

            // Solución del Error: Introducing FOREIGN KEY constraint 'FK_XXXXX' on table 'XXX' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
