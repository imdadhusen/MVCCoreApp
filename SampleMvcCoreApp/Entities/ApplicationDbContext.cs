using Microsoft.EntityFrameworkCore;
using SampleMvcCoreApp.Helper;
using SampleMvcCoreApp.IEntities;
using SampleMvcCoreApp.SeedData;
using System.Linq.Expressions;

namespace SampleMvcCoreApp.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<ParentCategory> ParentCategories { get; set; }
        public DbSet<ChildCategory> ChildCategories { get; set; }

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
            // Configure one-to-many relationship for Employee - Address 
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeAddress)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId);

            // Configure one-to-one relationship for Employee - Department 
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employee)
                .WithOne(a => a.Department)
                .HasForeignKey(a => a.DepartmentId);

            modelBuilder.Entity<ParentCategory>()
                .HasMany(c => c.ChildCategories)
                .WithOne(c => c.ParentCategory)
                .HasForeignKey(c => c.ParentCategoryId);

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

        public override int SaveChanges()
        {
            int currentUserId = _userContext.GetUserId(); // Assuming UserContext provides the current user's ID

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
            return base.SaveChanges();
        }
    }
}
