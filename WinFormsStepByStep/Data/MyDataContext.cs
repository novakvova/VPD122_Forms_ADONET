﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsStepByStep.Data.Entities;

namespace WinFormsStepByStep.Data
{
    public class MyDataContext : DbContext
    {
        public MyDataContext()
        {
            this.Database.Migrate();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder  optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=kotel-banan.mssql.somee.com;Database=kotel-banan;User Id=cojij78728_SQLLogin_1;Password=idb7e5zlvh;");
        }
    }
}