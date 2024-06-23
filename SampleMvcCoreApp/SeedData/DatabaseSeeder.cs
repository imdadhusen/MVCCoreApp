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

            modelBuilder.Entity<User>().HasData(
            new User() { Id = 1, Name = "Imdadhusen", Password = "imdad@123", Email = "Imdadhusen.sunasara@gmail.com", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC }
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

            //Seed data for Parent Category
            modelBuilder.Entity<ParentCategory>().HasData(
            new ParentCategory { Id = 1, Name = "House Hold Items", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 2, Name = "Offline Shopping", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 3, Name = "Online Shopping", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 4, Name = "Bills", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 5, Name = "Insurance", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 6, Name = "Education", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 7, Name = "Vehical Service", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 8, Name = "Fuel", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 9, Name = "Donation", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 10, Name = "Food", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 11, Name = "Doctor", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 12, Name = "Personal Care", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 13, Name = "Recharge", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 14, Name = "Tour (Picnic)", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ParentCategory { Id = 15, Name = "Personal", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC }
            );

            modelBuilder.Entity<ChildCategory>().HasData(
            new ChildCategory { Id = 1, ParentCategoryId = 12, Name = "Mobile", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 2, ParentCategoryId = 12, Name = "Watch", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 3, ParentCategoryId = 1, Name = "Electric", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 4, ParentCategoryId = 4, Name = "Maintenance", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 5, ParentCategoryId = 4, Name = "Property Tax", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 6, ParentCategoryId = 3, Name = "Kitchen", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 7, ParentCategoryId = 12, Name = "Bathroom", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 8, ParentCategoryId = 1, Name = "Rooms", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 9, ParentCategoryId = 10, Name = "Bread", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 10, ParentCategoryId = 10, Name = "Milk", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 11, ParentCategoryId = 10, Name = "Buttermilk", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 12, ParentCategoryId = 10, Name = "Curd", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 13, ParentCategoryId = 10, Name = "Juice", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 14, ParentCategoryId = 10, Name = "Coldrink", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 15, ParentCategoryId = 10, Name = "Icecreame", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 16, ParentCategoryId = 10, Name = "Egg", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 17, ParentCategoryId = 10, Name = "Pulses (Kathol)", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 18, ParentCategoryId = 10, Name = "Dalaman", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 19, ParentCategoryId = 10, Name = "Lunch", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 20, ParentCategoryId = 10, Name = "Dinner", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 21, ParentCategoryId = 10, Name = "Parcel", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 22, ParentCategoryId = 10, Name = "Nasto", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 23, ParentCategoryId = 10, Name = "Vegitables", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 24, ParentCategoryId = 10, Name = "Masala", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 25, ParentCategoryId = 10, Name = "Fruits", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 26, ParentCategoryId = 10, Name = "Fish", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 27, ParentCategoryId = 10, Name = "Mango", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 28, ParentCategoryId = 10, Name = "Sweets", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 29, ParentCategoryId = 10, Name = "Chicken", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 30, ParentCategoryId = 10, Name = "Oil", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 31, ParentCategoryId = 10, Name = "Bakery Items", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 32, ParentCategoryId = 10, Name = "Mutton", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 33, ParentCategoryId = 11, Name = "Dr Visit (Appointment)", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 34, ParentCategoryId = 11, Name = "Reports", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 35, ParentCategoryId = 11, Name = "Toothpaste", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 36, ParentCategoryId = 11, Name = "Medicine", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 37, ParentCategoryId = 9, Name = "Sadaka", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 38, ParentCategoryId = 9, Name = "Saiyad Saheb", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 39, ParentCategoryId = 9, Name = "Donation", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 40, ParentCategoryId = 9, Name = "Molvi Saheb", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 41, ParentCategoryId = 9, Name = "Mujawar", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 42, ParentCategoryId = 9, Name = "Dargah", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 43, ParentCategoryId = 9, Name = "Nyaz", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 44, ParentCategoryId = 9, Name = "Help", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 45, ParentCategoryId = 9, Name = "Imam Bargah", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 46, ParentCategoryId = 9, Name = "Masjid", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 47, ParentCategoryId = 9, Name = "Zakat & Khums", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 48, ParentCategoryId = 9, Name = "Watchman", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 49, ParentCategoryId = 15, Name = "Personal Expense", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 50, ParentCategoryId = 13, Name = "Mobile Recharge", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 51, ParentCategoryId = 13, Name = "Fast Tag", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 52, ParentCategoryId = 6, Name = "Fees", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 53, ParentCategoryId = 6, Name = "Tution", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 54, ParentCategoryId = 6, Name = "Stationary", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 55, ParentCategoryId = 6, Name = "Text Books", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 56, ParentCategoryId = 6, Name = "Note Books", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 57, ParentCategoryId = 6, Name = "School Dress", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 58, ParentCategoryId = 14, Name = "Hotel", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 59, ParentCategoryId = 14, Name = "Picnic", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 60, ParentCategoryId = 14, Name = "Tour", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 61, ParentCategoryId = 12, Name = "Cloths", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 62, ParentCategoryId = 12, Name = "Life Insurance", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 63, ParentCategoryId = 9, Name = "Islamic", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 64, ParentCategoryId = 9, Name = "Gift", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 65, ParentCategoryId = 12, Name = "Hair Cut", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 66, ParentCategoryId = 15, Name = "Transportation", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 67, ParentCategoryId = 12, Name = "Beauty", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 68, ParentCategoryId = 12, Name = "Shooe", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 69, ParentCategoryId = 12, Name = "Diaper", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 70, ParentCategoryId = 8, Name = "Petrol", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 71, ParentCategoryId = 8, Name = "GAS", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC },
            new ChildCategory { Id = 72, ParentCategoryId = 7, Name = "CAR", IsDeleted = false, IsActive = true, CreatedBy = 1, CreatedOn = DateHelper.GetUTC }
            );
        }
    }
}
