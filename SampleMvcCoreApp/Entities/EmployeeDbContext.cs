using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleMvcCoreApp.Controllers;
using SampleMvcCoreApp.Helper;
using SampleMvcCoreApp.SeedData;
using System.Linq.Expressions;

namespace SampleMvcCoreApp.Entities
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        private readonly ILogger<EmployeeDbContext> _logger;
        private readonly FilterService _filterService;
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options, ILogger<EmployeeDbContext> logger, FilterService filterService)
            : base(options)
        {
            _logger = logger;
            _filterService = filterService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //    //optionsBuilder.UseSqlServer("your_connection_string");
            //    //optionsBuilder.EnableSensitiveDataLogging();
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

            DatabaseSeeder.Seed(modelBuilder);
            _logger.LogInformation("Seed data completed");

            // Configure global query filter to exclude soft-deleted entities
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType);
                    var isDeletedProperty = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
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
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            //    {
            //        var parameter = Expression.Parameter(entityType.ClrType);
            //        var property = Expression.Property(parameter, "IsDeleted");
            //        var includeSoftDeleted = Expression.Constant(_filterService.IncludeSoftDeleted);
            //        var predicate = Expression.Lambda(Expression.Equal(property, includeSoftDeleted), parameter);
            //        modelBuilder.Entity(entityType.ClrType).HasQueryFilter((LambdaExpression)predicate);

            //        //var parameter = Expression.Parameter(entityType.ClrType);
            //        //var property = Expression.Property(parameter, "IsDeleted");
            //        //var value = Expression.Constant(false);
            //        //var predicate = Expression.Lambda(Expression.Equal(property, value), parameter);
            //        //var method = typeof(ExpressionHelper).GetMethod(nameof(ExpressionHelper.Compose)).MakeGenericMethod(entityType.ClrType);
            //        //var expression = method.Invoke(null, new object[] { predicate, entityType.GetQueryFilter() });
            //        //modelBuilder.Entity(entityType.ClrType).HasQueryFilter((LambdaExpression)expression);
            //    }
            //}
        }
    }
}
