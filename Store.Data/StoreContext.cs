using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Core.Enums;
using Store.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data
{
    public class StoreContext : IdentityDbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            //GUID
            string Admin_Role_Id = "9a00de05-ab2c-4692-82b2-d33f0f50eb7e";
            string Customer_Role_Id = "6472ca7d-4acb-4550-9b9f-2d03321ad5e6";
            string Admin_User_Id = "f1446937-109c-4e1a-97ce-0560442484f5";


            //Add Role
            Builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Admin_Role_Id,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = Admin_Role_Id

            });
            Builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Customer_Role_Id,
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = Customer_Role_Id
            });
            var adminUser = new ApplicationUser
            {
                Id = Admin_User_Id,
                FirstName = "Mahmoud",
                LastName = "Sameer",
                Email = "mahmoud@admin.com",
                NormalizedEmail = "MAHMOUD@ADMIN.COM",
                UserRole = UserRole.Administrator,
                UserName = "Mahmoud_Sameer",
                ImageName = "ma.jpg"

            };
            //Password Hasher
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "123456");
            Builder.Entity<ApplicationUser>().HasData(adminUser);
            //Add Role To AdminUser
            Builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = Admin_Role_Id,
                    UserId = Admin_User_Id
                }
                );
            base.OnModelCreating(Builder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShoppingCart> Carts { get; set; }
        public DbSet<ShoppingCartProducts> CartProducts { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
