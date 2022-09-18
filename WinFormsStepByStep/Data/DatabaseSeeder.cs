using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
                SeedBaskets(dataContext);
                SeedOrderStatuses(dataContext);
                SeedOrders(dataContext);
                SeedOrderItems(dataContext);
                SeedProductImages(dataContext);
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

        private static void SeedBaskets(MyDataContext dataContext)
        {
            if (!dataContext.Baskets.Any())
            {
                var basket = new Basket()
                {
                    UserId=1,
                    ProductId=2,
                    Count=2
                };
                dataContext.Baskets.Add(basket);
                dataContext.SaveChanges();

                var basket2 = new Basket()
                {
                    UserId = 1,
                    ProductId = 1,
                    Count = 1
                };
                dataContext.Baskets.Add(basket2);
                dataContext.SaveChanges();
            }
        }

        private static void SeedOrderStatuses(MyDataContext dataContext)
        {
            if (!dataContext.OrderStatuses.Any())
            {
                string[] statuses = { "Новий заказ", "Оброблено автоматично", 
                    "Виконано", "Прибув у віділення", "Скасовано" };
                foreach (var item in statuses)
                {
                    OrderStatus status = new OrderStatus
                    {
                        Name = item
                    };
                    dataContext.OrderStatuses.Add(status);
                    dataContext.SaveChanges();
                }
            }
        }

        private static void SeedOrders(MyDataContext dataContext)
        {
            if (!dataContext.Orders.Any())
            {
                var order = new Order
                {
                    StatusId = 1,
                    DateCreated = DateTime.Now,
                    UserId = 1
                };
                dataContext.Orders.Add(order);
                dataContext.SaveChanges();
            }
        }
        private static void SeedOrderItems(MyDataContext dataContext)
        {
            if (!dataContext.OrderItems.Any())
            {
                var orderItem = new OrderItem
                {
                    OrderId=1,
                    Count=2,
                    ProductId=1,
                    PriceBuy= 1150.45m
                };
                dataContext.OrderItems.Add(orderItem);
                dataContext.SaveChanges();

                var orderItem2 = new OrderItem
                {
                    OrderId = 1,
                    Count = 1,
                    ProductId = 2,
                    PriceBuy = 2245.89m
                };
                dataContext.OrderItems.Add(orderItem2);
                dataContext.SaveChanges();
            }
        }

        private static void SeedProductImages(MyDataContext dataContext)
        {
            if (!dataContext.ProductImages.Any())
            {
                var productImage = new ProductImage
                {
                    Name="1.jpg",
                    ProductId = 1,
                    Priority=1
                };
                dataContext.ProductImages.Add(productImage);
                dataContext.SaveChanges();

                var productImage2 = new ProductImage
                {
                    Name = "2.jpg",
                    ProductId = 1,
                    Priority = 2
                };
                dataContext.ProductImages.Add(productImage2);
                dataContext.SaveChanges();
            }
        }

    }
}
