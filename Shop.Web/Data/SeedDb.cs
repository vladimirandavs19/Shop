using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entities;
using Shop.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("vladivirus666@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Vladimir",
                    LastName = "Miranda",
                    UserName = "vladivirus666@gmail.com",
                    Email = "vladivirus666@gmail.com",
                    PhoneNumber = "593988340574",
                };

                var result = await this.userHelper.AddUserAsync(user, "admin123");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in seeder");
                }
            }

            if (!this.context.Products.Any())
            {
                this.AddProduct("IphoneX", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("iWatch Series 4", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                Stock = this.random.Next(100),
                IsAvailable = true,
                User = user,
            });
        }
    }
}
