using HisabPro.Constants;
using HisabPro.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HisabPro.Entities.SeedData
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //Seed data for Employee
            modelBuilder.Entity<Employee>().HasData(
            new Employee() { Id = 1, EmployeeName = "Test Emp1", Email = "Test@test.com", Skill = "Test1", DepartmentId = 1, Password = "Test1", CreatedBy = 1 },
            new Employee() { Id = 2, EmployeeName = "Test Emp2", Email = "Test2@test.com", Skill = "Test2", DepartmentId = 2, Password = "Test2", CreatedBy = 1 },
            new Employee() { Id = 3, EmployeeName = "Test Emp3", Email = "Test3@test.com", Skill = "Test3", DepartmentId = 3, Password = "Test3", CreatedBy = 1 },
            new Employee() { Id = 4, EmployeeName = "Soft Deleted Employee", Email = "SoftDelete@test.com", Skill = "Soft Delete", DepartmentId = 4, Password = "Deleted", IsDeleted = true, CreatedBy = 1 },
            new Employee() { Id = 5, EmployeeName = "Inactive Employee", Email = "Inactive@test.com", Skill = "In Active", DepartmentId = 4, Password = "Inactive", CreatedBy = 1, IsActive = false }
            );

            modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                Name = "Imdadhusen",
                Email = "Imdadhusen.sunasara@gmail.com",
                CreatedBy = 1,
                PasswordHash = "1vMi372tmTXw2LgItnQRh9bvTS88Am8ob0wfInqrdBXIV+1sIdcsw4j+48P2rUP2Kyt+UazOik1Yoflvdx+EwQ==",
                PasswordSalt = "xw6EbrRY1TTO1ef1Hclk4zFtWbfcHnTZgaw/K9+n05wYIKlaywZyRmn9VC0vGzklp1JaSQjtKoI0Wmf6FgUR4xbou/QJvqJlvzlYCLdrYbfXUyoLwdFJ90eNESfIHu8OfxGpzeKi8ceSEG6hieoEMnCp/wFnOogdGpz93pR1msU=",
                UserRole = (int)UserRoleEnum.Admin
            });

            //Seed data for Address
            modelBuilder.Entity<Address>().HasData(
            new Address { Id = 1, AddressDetail = "Ahmedabad", EmployeeId = 1, CreatedBy = 1 },
            new Address { Id = 2, AddressDetail = "Surat", EmployeeId = 1, CreatedBy = 1 },
            new Address { Id = 3, AddressDetail = "Patan", EmployeeId = 2, CreatedBy = 1 },
            new Address { Id = 4, AddressDetail = "Siddhpur", EmployeeId = 3, CreatedBy = 1 },
            new Address { Id = 5, AddressDetail = "Palanpur", EmployeeId = 4, CreatedBy = 1 },
            new Address { Id = 6, AddressDetail = "Ahmedabad", EmployeeId = 5, CreatedBy = 1 }
            );

            //Seed data for Department
            modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, DepartmentName = "Development", DepartmentPhone = "9909544184", CreatedBy = 1 },
            new Department { Id = 2, DepartmentName = "Testing", DepartmentPhone = null, CreatedBy = 1 },
            new Department { Id = 3, DepartmentName = "Human Resource", DepartmentPhone = null, CreatedBy = 1 },
            new Department { Id = 4, DepartmentName = "Finance", DepartmentPhone = null, CreatedBy = 1 },
            new Department { Id = 5, DepartmentName = "Marketing", DepartmentPhone = null, CreatedBy = 1 },
            new Department { Id = 6, DepartmentName = "Admin", DepartmentPhone = null, CreatedBy = 1 }
            );

            //Seed data for Parent Category
            modelBuilder.Entity<ParentCategory>().HasData(
            new ParentCategory { Id = 1, Name = "House Hold Items", CreatedBy = 1 },
            new ParentCategory { Id = 2, Name = "Offline Shopping", CreatedBy = 1 },
            new ParentCategory { Id = 3, Name = "Online Shopping", CreatedBy = 1 },
            new ParentCategory { Id = 4, Name = "Bills", CreatedBy = 1 },
            new ParentCategory { Id = 5, Name = "Insurance", CreatedBy = 1 },
            new ParentCategory { Id = 6, Name = "Education", CreatedBy = 1 },
            new ParentCategory { Id = 7, Name = "Vehical Service", CreatedBy = 1 },
            new ParentCategory { Id = 8, Name = "Fuel", CreatedBy = 1 },
            new ParentCategory { Id = 9, Name = "Donation", CreatedBy = 1 },
            new ParentCategory { Id = 10, Name = "Food", CreatedBy = 1 },
            new ParentCategory { Id = 11, Name = "Doctor", CreatedBy = 1 },
            new ParentCategory { Id = 12, Name = "Personal Care", CreatedBy = 1 },
            new ParentCategory { Id = 13, Name = "Recharge", CreatedBy = 1 },
            new ParentCategory { Id = 14, Name = "Tour (Picnic)", CreatedBy = 1 },
            new ParentCategory { Id = 15, Name = "Personal", CreatedBy = 1 },
            new ParentCategory { Id = 16, Name = "Investment", CreatedBy = 1 }
            );

            modelBuilder.Entity<ChildCategory>().HasData(
            new ChildCategory { Id = 1, ParentCategoryId = 12, Name = "Mobile", CreatedBy = 1 },
            new ChildCategory { Id = 2, ParentCategoryId = 12, Name = "Watch", CreatedBy = 1 },
            new ChildCategory { Id = 3, ParentCategoryId = 1, Name = "Electric", CreatedBy = 1 },
            new ChildCategory { Id = 4, ParentCategoryId = 4, Name = "Maintenance", CreatedBy = 1 },
            new ChildCategory { Id = 5, ParentCategoryId = 4, Name = "Property Tax", CreatedBy = 1 },
            new ChildCategory { Id = 6, ParentCategoryId = 3, Name = "Kitchen", CreatedBy = 1 },
            new ChildCategory { Id = 7, ParentCategoryId = 12, Name = "Bathroom", CreatedBy = 1 },
            new ChildCategory { Id = 8, ParentCategoryId = 1, Name = "Rooms", CreatedBy = 1 },
            new ChildCategory { Id = 9, ParentCategoryId = 10, Name = "Bread", CreatedBy = 1 },
            new ChildCategory { Id = 10, ParentCategoryId = 10, Name = "Milk", CreatedBy = 1 },
            new ChildCategory { Id = 11, ParentCategoryId = 10, Name = "Buttermilk", CreatedBy = 1 },
            new ChildCategory { Id = 12, ParentCategoryId = 10, Name = "Curd", CreatedBy = 1 },
            new ChildCategory { Id = 13, ParentCategoryId = 10, Name = "Juice", CreatedBy = 1 },
            new ChildCategory { Id = 14, ParentCategoryId = 10, Name = "Coldrink", CreatedBy = 1 },
            new ChildCategory { Id = 15, ParentCategoryId = 10, Name = "Icecreame", CreatedBy = 1 },
            new ChildCategory { Id = 16, ParentCategoryId = 10, Name = "Egg", CreatedBy = 1 },
            new ChildCategory { Id = 17, ParentCategoryId = 10, Name = "Pulses (Kathol)", CreatedBy = 1 },
            new ChildCategory { Id = 18, ParentCategoryId = 10, Name = "Dalaman", CreatedBy = 1 },
            new ChildCategory { Id = 19, ParentCategoryId = 10, Name = "Lunch", CreatedBy = 1 },
            new ChildCategory { Id = 20, ParentCategoryId = 10, Name = "Dinner", CreatedBy = 1 },
            new ChildCategory { Id = 21, ParentCategoryId = 10, Name = "Parcel", CreatedBy = 1 },
            new ChildCategory { Id = 22, ParentCategoryId = 10, Name = "Nasto", CreatedBy = 1 },
            new ChildCategory { Id = 23, ParentCategoryId = 10, Name = "Vegitables", CreatedBy = 1 },
            new ChildCategory { Id = 24, ParentCategoryId = 10, Name = "Masala", CreatedBy = 1 },
            new ChildCategory { Id = 25, ParentCategoryId = 10, Name = "Fruits", CreatedBy = 1 },
            new ChildCategory { Id = 26, ParentCategoryId = 10, Name = "Fish", CreatedBy = 1 },
            new ChildCategory { Id = 27, ParentCategoryId = 10, Name = "Mango", CreatedBy = 1 },
            new ChildCategory { Id = 28, ParentCategoryId = 10, Name = "Sweets", CreatedBy = 1 },
            new ChildCategory { Id = 29, ParentCategoryId = 10, Name = "Chicken", CreatedBy = 1 },
            new ChildCategory { Id = 30, ParentCategoryId = 10, Name = "Oil", CreatedBy = 1 },
            new ChildCategory { Id = 31, ParentCategoryId = 10, Name = "Bakery Items", CreatedBy = 1 },
            new ChildCategory { Id = 32, ParentCategoryId = 10, Name = "Mutton", CreatedBy = 1 },
            new ChildCategory { Id = 33, ParentCategoryId = 11, Name = "Dr Visit (Appointment)", CreatedBy = 1 },
            new ChildCategory { Id = 34, ParentCategoryId = 11, Name = "Reports", CreatedBy = 1 },
            new ChildCategory { Id = 35, ParentCategoryId = 11, Name = "Toothpaste", CreatedBy = 1 },
            new ChildCategory { Id = 36, ParentCategoryId = 11, Name = "Medicine", CreatedBy = 1 },
            new ChildCategory { Id = 37, ParentCategoryId = 9, Name = "Sadaka", CreatedBy = 1 },
            new ChildCategory { Id = 38, ParentCategoryId = 9, Name = "Saiyad Saheb", CreatedBy = 1 },
            new ChildCategory { Id = 39, ParentCategoryId = 9, Name = "Donation", CreatedBy = 1 },
            new ChildCategory { Id = 40, ParentCategoryId = 9, Name = "Molvi Saheb", CreatedBy = 1 },
            new ChildCategory { Id = 41, ParentCategoryId = 9, Name = "Mujawar", CreatedBy = 1 },
            new ChildCategory { Id = 42, ParentCategoryId = 9, Name = "Dargah", CreatedBy = 1 },
            new ChildCategory { Id = 43, ParentCategoryId = 9, Name = "Nyaz", CreatedBy = 1 },
            new ChildCategory { Id = 44, ParentCategoryId = 9, Name = "Help", CreatedBy = 1 },
            new ChildCategory { Id = 45, ParentCategoryId = 9, Name = "Imam Bargah", CreatedBy = 1 },
            new ChildCategory { Id = 46, ParentCategoryId = 9, Name = "Masjid", CreatedBy = 1 },
            new ChildCategory { Id = 47, ParentCategoryId = 9, Name = "Zakat & Khums", CreatedBy = 1 },
            new ChildCategory { Id = 48, ParentCategoryId = 9, Name = "Watchman", CreatedBy = 1 },
            new ChildCategory { Id = 49, ParentCategoryId = 15, Name = "Personal Expense", CreatedBy = 1 },
            new ChildCategory { Id = 50, ParentCategoryId = 13, Name = "Mobile Recharge", CreatedBy = 1 },
            new ChildCategory { Id = 51, ParentCategoryId = 13, Name = "Fast Tag", CreatedBy = 1 },
            new ChildCategory { Id = 52, ParentCategoryId = 6, Name = "Fees", CreatedBy = 1 },
            new ChildCategory { Id = 53, ParentCategoryId = 6, Name = "Tution", CreatedBy = 1 },
            new ChildCategory { Id = 54, ParentCategoryId = 6, Name = "Stationary", CreatedBy = 1 },
            new ChildCategory { Id = 55, ParentCategoryId = 6, Name = "Text Books", CreatedBy = 1 },
            new ChildCategory { Id = 56, ParentCategoryId = 6, Name = "Note Books", CreatedBy = 1 },
            new ChildCategory { Id = 57, ParentCategoryId = 6, Name = "School Dress", CreatedBy = 1 },
            new ChildCategory { Id = 58, ParentCategoryId = 14, Name = "Hotel", CreatedBy = 1 },
            new ChildCategory { Id = 59, ParentCategoryId = 14, Name = "Picnic", CreatedBy = 1 },
            new ChildCategory { Id = 60, ParentCategoryId = 14, Name = "Tour", CreatedBy = 1 },
            new ChildCategory { Id = 61, ParentCategoryId = 12, Name = "Cloths", CreatedBy = 1 },
            new ChildCategory { Id = 62, ParentCategoryId = 12, Name = "Life Insurance", CreatedBy = 1 },
            new ChildCategory { Id = 63, ParentCategoryId = 9, Name = "Islamic", CreatedBy = 1 },
            new ChildCategory { Id = 64, ParentCategoryId = 9, Name = "Gift", CreatedBy = 1 },
            new ChildCategory { Id = 65, ParentCategoryId = 12, Name = "Hair Cut", CreatedBy = 1 },
            new ChildCategory { Id = 66, ParentCategoryId = 15, Name = "Transportation", CreatedBy = 1 },
            new ChildCategory { Id = 67, ParentCategoryId = 12, Name = "Beauty", CreatedBy = 1 },
            new ChildCategory { Id = 68, ParentCategoryId = 12, Name = "Shooe", CreatedBy = 1 },
            new ChildCategory { Id = 69, ParentCategoryId = 12, Name = "Diaper", CreatedBy = 1 },
            new ChildCategory { Id = 70, ParentCategoryId = 8, Name = "Petrol", CreatedBy = 1 },
            new ChildCategory { Id = 71, ParentCategoryId = 8, Name = "GAS", CreatedBy = 1 },
            new ChildCategory { Id = 72, ParentCategoryId = 7, Name = "CAR", CreatedBy = 1 },
            new ChildCategory { Id = 73, ParentCategoryId = 8, Name = "Cash", CreatedBy = 1 },
            new ChildCategory { Id = 74, ParentCategoryId = 7, Name = "Online Transfer", CreatedBy = 1 }
            );
        }
    }
}
