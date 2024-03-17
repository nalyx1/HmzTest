using HmzTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HmzTest.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<UserModel>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var roles = new List<IdentityRole>
            {
                new() {
                    Id = "1af9ec13-322f-477a-bc92-afa2f767c1f2", 
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new() {
                    Id = "2bf9ec13-322f-477a-bc92-afa2f767c1f2",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            var hasher = new PasswordHasher<UserModel>();

            var users = new List<UserModel>
            {
                new()
                {
                    Id = "3cf9ec13-322f-477a-bc92-afa2f767c1f2",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "HmzTest123!"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new() 
                {
                    Id = "4df9ec13-322f-477a-bc92-afa2f767c1f2",
                    UserName = "user1",
                    NormalizedUserName = "USER1",
                    Email = "user1@example.com",
                    NormalizedEmail = "USER1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "HmzTest123!"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                 new()
                {
                    Id = "5ef9ec13-322f-477a-bc92-afa2f767c1f2",
                    UserName = "user2",
                    NormalizedUserName = "USER2",
                    Email = "user2@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "HmzTest123!"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };

            modelBuilder.Entity<UserModel>().HasData(users);

            var usersRole = new List<IdentityUserRole<string>>
            {
               new()
               {
                   RoleId = roles[0].Id,
                   UserId = users[0].Id,
               },
               new()
               {
                   RoleId = roles[1].Id,
                   UserId = users[1].Id
               },
               new()
               {
                   RoleId = roles[1].Id,
                   UserId = users[2].Id
               }
            };

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(usersRole);
           
        }

    }
}