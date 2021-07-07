using Application.Common.Interface;
using Domain.Entities.Common;
using Domain.Entities.Particapant;
using Domain.Entities.Tournament;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Infastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(DbContextOptions options,
            IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cencellationToken)
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ModificationEntity> entry in ChangeTracker.Entries<ModificationEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cencellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
