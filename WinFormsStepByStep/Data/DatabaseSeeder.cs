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

    }
}
