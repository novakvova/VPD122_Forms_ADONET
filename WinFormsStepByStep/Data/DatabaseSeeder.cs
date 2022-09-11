using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsStepByStep.Data.Entities;

namespace WinFormsStepByStep.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed()
        {
            using (MyDataContext dataContext = new MyDataContext())
            {
                SeedUsers(dataContext);
                SeedProducts(dataContext);
            }

        }
        private static void SeedUsers(MyDataContext dataContext)
        {
            if(!dataContext.Users.Any())
            {
                var user = new User()
                {
                    FirstName = "Юхим",
                    LastName = "Жарить",
                    Email = "admin@gmail.com",
                    Phone = "+380 98 89 67 786"
                };
                dataContext.Users.Add(user);
                dataContext.SaveChanges();
            }
        }

        private static void SeedProducts(MyDataContext dataContext)
        {
            if (!dataContext.Products.Any())
            {
                var product = new Product()
                {
                    Name="Sdd 256 Gb",
                    Price=1200.45m,
                    Description="Для звчайних пацанів"
                };
                dataContext.Products.Add(product);
                dataContext.SaveChanges();

                var product2 = new Product()
                {
                    Name = "DDR4 16 Gb",
                    Price = 2245.89m,
                    Description = "Для крутий парнів"
                };
                dataContext.Products.Add(product2);
                dataContext.SaveChanges();
            }
        }

    }
}
