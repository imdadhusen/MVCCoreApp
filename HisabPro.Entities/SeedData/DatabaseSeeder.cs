using HisabPro.Constants;
using HisabPro.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HisabPro.Entities.SeedData
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                Name = "Imdadhusen",
                Email = "Imdadhusen.sunasara@gmail.com",
                CreatedBy = 1,
                PasswordHash = "1vMi372tmTXw2LgItnQRh9bvTS88Am8ob0wfInqrdBXIV+1sIdcsw4j+48P2rUP2Kyt+UazOik1Yoflvdx+EwQ==",
                PasswordSalt = "xw6EbrRY1TTO1ef1Hclk4zFtWbfcHnTZgaw/K9+n05wYIKlaywZyRmn9VC0vGzklp1JaSQjtKoI0Wmf6FgUR4xbou/QJvqJlvzlYCLdrYbfXUyoLwdFJ90eNESfIHu8OfxGpzeKi8ceSEG6hieoEMnCp/wFnOogdGpz93pR1msU=",
                UserRole = (int)UserRoleEnum.Admin,
                Gender = (int)UserGenederEnum.Male,
                Mobile = "9909544184"
            });

            //Seed data for Category
            //Expense Category and Sub Category
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "House Hold Items", CreatedBy = 1, IsStandard = true },
            new Category { Id = 2, Name = "Offline Shopping", CreatedBy = 1, IsStandard = true },
            new Category { Id = 3, Name = "Online Shopping", CreatedBy = 1, IsStandard = true },
            new Category { Id = 4, Name = "Bills", CreatedBy = 1, IsStandard = true },
            new Category { Id = 5, Name = "Insurance", CreatedBy = 1, IsStandard = true },
            new Category { Id = 6, Name = "Education", CreatedBy = 1, IsStandard = true },
            new Category { Id = 7, Name = "Vehical Service", CreatedBy = 1, IsStandard = true },
            new Category { Id = 8, Name = "Fuel", CreatedBy = 1, IsStandard = true },
            new Category { Id = 9, Name = "Donation", CreatedBy = 1, IsStandard = true },
            new Category { Id = 10, Name = "Food", CreatedBy = 1, IsStandard = true },
            new Category { Id = 11, Name = "Doctor", CreatedBy = 1, IsStandard = true },
            new Category { Id = 12, Name = "Personal Care", CreatedBy = 1, IsStandard = true },
            new Category { Id = 13, Name = "Recharge", CreatedBy = 1, IsStandard = true },
            new Category { Id = 14, Name = "Tour (Picnic)", CreatedBy = 1, IsStandard = true },
            new Category { Id = 15, Name = "Personal", CreatedBy = 1, IsStandard = true },
            new Category { Id = 16, Name = "Investment", CreatedBy = 1, IsStandard = true },

            new Category { Id = 17, ParentId = 10, Name = "Pulses (Kathol)", CreatedBy = 1, IsStandard = true },
            new Category { Id = 18, ParentId = 10, Name = "Dalaman", CreatedBy = 1, IsStandard = true },
            new Category { Id = 19, ParentId = 10, Name = "Lunch", CreatedBy = 1, IsStandard = true },
            new Category { Id = 20, ParentId = 10, Name = "Dinner", CreatedBy = 1, IsStandard = true },
            new Category { Id = 21, ParentId = 10, Name = "Parcel", CreatedBy = 1, IsStandard = true },
            new Category { Id = 22, ParentId = 10, Name = "Nasto", CreatedBy = 1, IsStandard = true },
            new Category { Id = 23, ParentId = 10, Name = "Vegitables", CreatedBy = 1, IsStandard = true },
            new Category { Id = 24, ParentId = 10, Name = "Masala", CreatedBy = 1, IsStandard = true },
            new Category { Id = 25, ParentId = 10, Name = "Fruits", CreatedBy = 1, IsStandard = true },
            new Category { Id = 26, ParentId = 10, Name = "Fish", CreatedBy = 1, IsStandard = true },
            new Category { Id = 27, ParentId = 10, Name = "Mango", CreatedBy = 1, IsStandard = true },
            new Category { Id = 28, ParentId = 10, Name = "Sweets", CreatedBy = 1, IsStandard = true },
            new Category { Id = 29, ParentId = 10, Name = "Chicken", CreatedBy = 1, IsStandard = true },
            new Category { Id = 30, ParentId = 10, Name = "Oil", CreatedBy = 1, IsStandard = true },
            new Category { Id = 31, ParentId = 10, Name = "Bakery Items", CreatedBy = 1, IsStandard = true },
            new Category { Id = 32, ParentId = 10, Name = "Mutton", CreatedBy = 1, IsStandard = true },
            new Category { Id = 33, ParentId = 11, Name = "Dr Visit (Appointment)", CreatedBy = 1, IsStandard = true },
            new Category { Id = 34, ParentId = 11, Name = "Reports", CreatedBy = 1, IsStandard = true },
            new Category { Id = 35, ParentId = 11, Name = "Toothpaste", CreatedBy = 1, IsStandard = true },
            new Category { Id = 36, ParentId = 11, Name = "Medicine", CreatedBy = 1, IsStandard = true },
            new Category { Id = 37, ParentId = 9, Name = "Sadaka", CreatedBy = 1, IsStandard = true },
            new Category { Id = 38, ParentId = 9, Name = "Saiyad Saheb", CreatedBy = 1, IsStandard = true },
            new Category { Id = 39, ParentId = 9, Name = "Donation", CreatedBy = 1, IsStandard = true },
            new Category { Id = 40, ParentId = 9, Name = "Molvi Saheb", CreatedBy = 1, IsStandard = true },
            new Category { Id = 41, ParentId = 9, Name = "Mujawar", CreatedBy = 1, IsStandard = true },
            new Category { Id = 42, ParentId = 9, Name = "Dargah", CreatedBy = 1, IsStandard = true },
            new Category { Id = 43, ParentId = 9, Name = "Nyaz", CreatedBy = 1, IsStandard = true },
            new Category { Id = 44, ParentId = 9, Name = "Help", CreatedBy = 1, IsStandard = true },
            new Category { Id = 45, ParentId = 9, Name = "Imam Bargah", CreatedBy = 1, IsStandard = true },
            new Category { Id = 46, ParentId = 9, Name = "Masjid", CreatedBy = 1, IsStandard = true },
            new Category { Id = 47, ParentId = 9, Name = "Zakat & Khums", CreatedBy = 1, IsStandard = true },
            new Category { Id = 48, ParentId = 9, Name = "Watchman", CreatedBy = 1, IsStandard = true },
            new Category { Id = 49, ParentId = 15, Name = "Personal Expense", CreatedBy = 1, IsStandard = true },
            new Category { Id = 50, ParentId = 13, Name = "Mobile Recharge", CreatedBy = 1, IsStandard = true },
            new Category { Id = 51, ParentId = 13, Name = "Fast Tag", CreatedBy = 1, IsStandard = true },
            new Category { Id = 52, ParentId = 6, Name = "Fees", CreatedBy = 1, IsStandard = true },
            new Category { Id = 53, ParentId = 6, Name = "Tution", CreatedBy = 1, IsStandard = true },
            new Category { Id = 54, ParentId = 6, Name = "Stationary", CreatedBy = 1, IsStandard = true },
            new Category { Id = 55, ParentId = 6, Name = "Text Books", CreatedBy = 1, IsStandard = true },
            new Category { Id = 56, ParentId = 6, Name = "Note Books", CreatedBy = 1, IsStandard = true },
            new Category { Id = 57, ParentId = 6, Name = "School Dress", CreatedBy = 1, IsStandard = true },
            new Category { Id = 58, ParentId = 14, Name = "Hotel", CreatedBy = 1, IsStandard = true },
            new Category { Id = 59, ParentId = 14, Name = "Picnic", CreatedBy = 1, IsStandard = true },
            new Category { Id = 60, ParentId = 14, Name = "Tour", CreatedBy = 1, IsStandard = true },
            new Category { Id = 61, ParentId = 12, Name = "Cloths", CreatedBy = 1, IsStandard = true },
            new Category { Id = 62, ParentId = 5, Name = "Life Insurance", CreatedBy = 1, IsStandard = true },
            new Category { Id = 63, ParentId = 9, Name = "Islamic", CreatedBy = 1, IsStandard = true },
            new Category { Id = 64, ParentId = 9, Name = "Gift", CreatedBy = 1, IsStandard = true },
            new Category { Id = 65, ParentId = 12, Name = "Hair Cut", CreatedBy = 1, IsStandard = true },
            new Category { Id = 66, ParentId = 15, Name = "Transportation", CreatedBy = 1, IsStandard = true },
            new Category { Id = 67, ParentId = 12, Name = "Beauty", CreatedBy = 1, IsStandard = true },
            new Category { Id = 68, ParentId = 12, Name = "Shooe", CreatedBy = 1, IsStandard = true },
            new Category { Id = 69, ParentId = 12, Name = "Diaper", CreatedBy = 1, IsStandard = true },
            new Category { Id = 70, ParentId = 8, Name = "Petrol", CreatedBy = 1, IsStandard = true },
            new Category { Id = 71, ParentId = 8, Name = "GAS", CreatedBy = 1, IsStandard = true },
            new Category { Id = 72, ParentId = 7, Name = "CAR", CreatedBy = 1, IsStandard = true },
            new Category { Id = 73, ParentId = 16, Name = "Cash", CreatedBy = 1, IsStandard = true },
            new Category { Id = 74, ParentId = 16, Name = "Online Transfer", CreatedBy = 1, IsStandard = true },
            new Category { Id = 75, ParentId = 2, Name = "Mall", CreatedBy = 1, IsStandard = true },
            new Category { Id = 76, ParentId = 12, Name = "Mobile", CreatedBy = 1, IsStandard = true },
            new Category { Id = 77, ParentId = 12, Name = "Watch", CreatedBy = 1, IsStandard = true },
            new Category { Id = 78, ParentId = 1, Name = "Electric", CreatedBy = 1, IsStandard = true },
            new Category { Id = 79, ParentId = 4, Name = "Maintenance", CreatedBy = 1, IsStandard = true },
            new Category { Id = 80, ParentId = 4, Name = "Property Tax", CreatedBy = 1, IsStandard = true },
            new Category { Id = 81, ParentId = 3, Name = "Kitchen", CreatedBy = 1, IsStandard = true },
            new Category { Id = 82, ParentId = 12, Name = "Bathroom", CreatedBy = 1, IsStandard = true },
            new Category { Id = 83, ParentId = 1, Name = "Rooms", CreatedBy = 1, IsStandard = true },
            new Category { Id = 84, ParentId = 10, Name = "Bread", CreatedBy = 1, IsStandard = true },
            new Category { Id = 85, ParentId = 10, Name = "Milk", CreatedBy = 1, IsStandard = true },
            new Category { Id = 86, ParentId = 10, Name = "Buttermilk", CreatedBy = 1, IsStandard = true },
            new Category { Id = 87, ParentId = 10, Name = "Curd", CreatedBy = 1, IsStandard = true },
            new Category { Id = 88, ParentId = 10, Name = "Juice", CreatedBy = 1, IsStandard = true },
            new Category { Id = 89, ParentId = 10, Name = "Coldrink", CreatedBy = 1, IsStandard = true },
            new Category { Id = 90, ParentId = 10, Name = "Icecreame", CreatedBy = 1, IsStandard = true },
            new Category { Id = 91, ParentId = 10, Name = "Egg", CreatedBy = 1, IsStandard = true },

            //Income Category and Sub Category
            new Category { Id = 92, Name = "Job", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 93, Name = "Business", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 94, Name = "Gift", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 95, Name = "Investment", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 96, Name = "Item Sold", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 97, Name = "Insurance", CreatedBy = 1, IsStandard = true, Type = 2 },

            new Category { Id = 98, ParentId = 92, Name = "Salary", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 99, ParentId = 92, Name = "Incentive", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 100, ParentId = 92, Name = "Bonus", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 101, ParentId = 92, Name = "Performance", CreatedBy = 1, IsStandard = true, Type = 2 },

            new Category { Id = 102, ParentId = 93, Name = "Profit", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 103, ParentId = 93, Name = "Capital", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 104, ParentId = 93, Name = "Soldout", CreatedBy = 1, IsStandard = true, Type = 2 },

            new Category { Id = 105, ParentId = 94, Name = "Social Function", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 106, ParentId = 94, Name = "Personal", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 107, ParentId = 94, Name = "Lucky Draw", CreatedBy = 1, IsStandard = true, Type = 2 },

            new Category { Id = 108, ParentId = 95, Name = "Property", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 109, ParentId = 95, Name = "Bank Interest", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 110, ParentId = 95, Name = "Society", CreatedBy = 1, IsStandard = true, Type = 2 },

            new Category { Id = 111, ParentId = 96, Name = "Stationary", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 112, ParentId = 96, Name = "Scrap (Bhangar)", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 113, ParentId = 96, Name = "Vehicale", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 114, ParentId = 96, Name = "House Hold Item", CreatedBy = 1, IsStandard = true, Type = 2 },

            new Category { Id = 115, ParentId = 97, Name = "Insurance Maturity", CreatedBy = 1, IsStandard = true, Type = 2 },
            new Category { Id = 116, ParentId = 97, Name = "Insurance Return", CreatedBy = 1, IsStandard = true, Type = 2 });
        }

        public static void ExecutePostSeedSql(DbContext context)
        {
            // Execute the SQL script after the seed
            context.Database.ExecuteSqlRaw(@"
            UPDATE [dbo].[Users] SET [CreatedOn]=GETUTCDATE() WHERE [CreatedOn] IS NULL;
            UPDATE [dbo].[Categories] SET [CreatedOn]=GETUTCDATE() WHERE [CreatedOn] IS NULL;");
        }
    }
}
