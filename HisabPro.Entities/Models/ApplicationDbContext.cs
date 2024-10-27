using HisabPro.Common;
using HisabPro.Entities.IEntities;
using HisabPro.Entities.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace HisabPro.Entities.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ParentCategory> ParentCategories { get; set; }
        public DbSet<ChildCategory> ChildCategories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        private readonly ILogger<ApplicationDbContext> _logger;
        private readonly FilterService _filterService;
        private readonly IUserContext _userContext;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILogger<ApplicationDbContext> logger, FilterService filterService, IUserContext userContext)
            : base(options)
        {
            _logger = logger;
            _filterService = filterService;
            _userContext = userContext;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure self-referencing relationships in the User entity
            modelBuilder.Entity<User>().HasOne(u => u.Creator).WithMany().HasForeignKey(u => u.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasOne(u => u.Modifier).WithMany().HasForeignKey(u => u.ModifiedBy).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().Property(p => p.CreatedOn).HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<ParentCategory>().HasMany(c => c.ChildCategories).WithOne(c => c.ParentCategory).HasForeignKey(c => c.ParentCategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ParentCategory>().HasOne(p => p.Creator).WithMany().HasForeignKey(p => p.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ParentCategory>().HasOne(p => p.Modifier).WithMany().HasForeignKey(p => p.ModifiedBy).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ParentCategory>().Property(p => p.CreatedOn).HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<ChildCategory>().HasOne(c => c.Creator).WithMany().HasForeignKey(c => c.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ChildCategory>().HasOne(c => c.Modifier).WithMany().HasForeignKey(c => c.ModifiedBy).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ChildCategory>().Property(p => p.CreatedOn).HasDefaultValueSql("GETUTCDATE()");

            // Configure relationship for Account - Income and Expense
            modelBuilder.Entity<Account>().HasMany(e => e.Incomes).WithOne(a => a.Account).HasForeignKey(a => a.AccountId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Account>().HasMany(e => e.Expenses).WithOne(a => a.Account).HasForeignKey(a => a.AccountId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Account>().HasOne(p => p.Creator).WithMany().HasForeignKey(p => p.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Account>().HasOne(p => p.Modifier).WithMany().HasForeignKey(p => p.ModifiedBy).OnDelete(DeleteBehavior.Restrict);

            // Configure relationship for Income 
            modelBuilder.Entity<Income>().HasOne(p => p.Creator).WithMany().HasForeignKey(p => p.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Income>().HasOne(p => p.Modifier).WithMany().HasForeignKey(p => p.ModifiedBy).OnDelete(DeleteBehavior.Restrict);

            // Configure relationship for Expense 
            modelBuilder.Entity<Expense>().HasOne(p => p.Creator).WithMany().HasForeignKey(p => p.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Expense>().HasOne(p => p.Modifier).WithMany().HasForeignKey(p => p.ModifiedBy).OnDelete(DeleteBehavior.Restrict);

            DatabaseSeeder.Seed(modelBuilder);
            _logger.LogInformation("Seed data completed");

            // Configure global query filter to exclude soft-deleted entities
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IAuditableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType);
                    var isDeletedProperty = Expression.Property(parameter, nameof(IAuditableEntity.IsDeleted));
                    var includeSoftDeleted = Expression.Constant(_filterService.IncludeSoftDeleted);
                    var condition = Expression.Equal(isDeletedProperty, includeSoftDeleted);
                    var lambda = Expression.Lambda(condition, parameter);

                    // Ensure the global filter considers the dynamic flag
                    if (_filterService.IncludeSoftDeleted)
                    {
                        modelBuilder.Entity(entityType.ClrType).HasQueryFilter((LambdaExpression)lambda);
                    }
                    else
                    {
                        var notDeletedCondition = Expression.Not(isDeletedProperty);
                        var notDeletedLambda = Expression.Lambda(notDeletedCondition, parameter);
                        modelBuilder.Entity(entityType.ClrType).HasQueryFilter((LambdaExpression)notDeletedLambda);
                    }
                }
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int currentUserId = _userContext.GetCurrentUserId();

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is AuditableEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedOn = DateHelper.GetUTC;
                            entity.ModifiedOn = DateHelper.GetUTC;
                            entity.CreatedBy = currentUserId;
                            entity.ModifiedBy = currentUserId;
                            break;
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            Entry(entity).Property(x => x.CreatedOn).IsModified = false;
                            entity.ModifiedOn = DateHelper.GetUTC;
                            entity.ModifiedBy = currentUserId;
                            break;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
