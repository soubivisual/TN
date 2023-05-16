using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using TN.Modules.Buildings.Shared.SharedKernel;
using TN.Modules.Buildings.Shared.Tenants;

namespace TN.Modules.Buildings.Shared.Persistance.Database
{
    public class DbContextBase : DbContext
    {
        private int? _tenantId;

        public DbContextBase(DbContextOptions options, ITenantService tenantService) : base(options) 
        { 
            _tenantId = tenantService.GetTenantId();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

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

            foreach(var entity in modelBuilder.Model.GetEntityTypes())
            {
                var type = entity.ClrType;

                if (typeof(ITenantEntity).IsAssignableFrom(type))
                {
                    var method = typeof(DbContextBase).GetMethod(nameof(GlobalTenantFilter),BindingFlags.NonPublic | BindingFlags.Static)?.MakeGenericMethod(type);
                    var filter = method.Invoke(null, new object[] { this });
                    entity.SetQueryFilter((LambdaExpression)filter);
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var item in ChangeTracker.Entries().Where(x => x.State == EntityState.Added && x.Entity is ITenantEntity))
            {
                if (_tenantId == default)
                {
                    throw new Exception("TenantId no encontrado al momento de crear el registro");
                }
                    
                var entity = item.Entity as ITenantEntity;
                entity.TenantId = _tenantId;
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }

        private static LambdaExpression GlobalTenantFilter<TEntity>(DbContextBase context) where TEntity : class, ITenantEntity
        {
            Expression<Func<TEntity, bool>> filter = x => x.TenantId == context._tenantId;
            return filter;
        }
    }
}
