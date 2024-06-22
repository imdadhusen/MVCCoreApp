using Microsoft.EntityFrameworkCore;
using SampleMvcCoreApp.Entities;
using SampleMvcCoreApp.Helper;

namespace SampleMvcCoreApp.SeedData
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //Seed data for Employee
            modelBuilder.Entity<Employee>().HasData(
            new Employee() { Id = 1, EmployeeName = "Test Emp1", Email = "Test@test.com", Skill = "Test1", DepartmentId = 1, Password = "Test1", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Employee() { Id = 2, EmployeeName = "Test Emp2", Email = "Test2@test.com", Skill = "Test2", DepartmentId = 2, Password = "Test2", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Employee() { Id = 3, EmployeeName = "Test Emp3", Email = "Test3@test.com", Skill = "Test3", DepartmentId = 3, Password = "Test3", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Employee() { Id = 4, EmployeeName = "Soft Deleted Employee", Email = "SoftDelete@test.com", Skill = "Soft Delete", DepartmentId = 4, Password = "Deleted", IsDeleted = true, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Employee() { Id = 5, EmployeeName = "Inactive Employee", Email = "Inactive@test.com", Skill = "In Active", DepartmentId = 4, Password = "Inactive", IsDeleted = false, IsActive = false, CreatedBy = 1, CreatedOn = DateHelper.GetUTC }
            );

            //Seed data for Address
            modelBuilder.Entity<Address>().HasData(
            new Address { Id = 1, AddressDetail = "Ahmedabad", EmployeeId = 1, IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Address { Id = 2, AddressDetail = "Surat", EmployeeId = 1, IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Address { Id = 3, AddressDetail = "Patan", EmployeeId = 2, IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Address { Id = 4, AddressDetail = "Siddhpur", EmployeeId = 3, IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Address { Id = 5, AddressDetail = "Palanpur", EmployeeId = 4, IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Address { Id = 6, AddressDetail = "Ahmedabad", EmployeeId = 5, IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC }
            );

            //Seed data for Department
            modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, DepartmentName = "Development", DepartmentPhone = "9909544184", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Department { Id = 2, DepartmentName = "Testing", DepartmentPhone = null, IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Department { Id = 3, DepartmentName = "Human Resource", DepartmentPhone = null, IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Department { Id = 4, DepartmentName = "Finance", DepartmentPhone = null, IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Department { Id = 5, DepartmentName = "Marketing", DepartmentPhone = null, IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new Department { Id = 6, DepartmentName = "Admin", DepartmentPhone = null, IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC }
            );
        }
    }
}
