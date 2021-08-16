using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using UltraPlayTask.Data.Models;

namespace UltraPlayTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BettingDemo;Integrated Security=true");
            }
        }


        public DbSet<Bet> Bets { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Odd> Odds { get; set; }

        protected void SetGlobalSoftDeleteQueryFilter(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var isDeletedProperty = entityType.FindProperty("IsDeleted");
                if (isDeletedProperty != null
                    && isDeletedProperty.ClrType == typeof(bool))
                {
                    var parameter = Expression.Parameter(
                        entityType.ClrType, "p");
                    var prop = Expression.Property(parameter,
                        isDeletedProperty.PropertyInfo);
                    var filter = Expression.Lambda(Expression.Not(prop),
                        parameter);
                    entityType.SetQueryFilter(filter);
                }
            }
        }


        private void SetSoftDeleteColumns()
        {
            var entriesDeleted = ChangeTracker
                .Entries()
                .Where(e => e.Entity is ISoftDelete
                        && e.State == EntityState.Deleted);

            foreach (var entityEntry in entriesDeleted)
            {
                ((ISoftDelete)entityEntry.Entity).IsDeleted = true;
                ((ISoftDelete)entityEntry.Entity).DeletionDateTime =
                        DateTimeOffset.Now;
                entityEntry.State = EntityState.Modified;
            }
        }

        public override int SaveChanges()
        {
            SetSoftDeleteColumns();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            SetSoftDeleteColumns();

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SetGlobalSoftDeleteQueryFilter(builder);
        }
    }
}
