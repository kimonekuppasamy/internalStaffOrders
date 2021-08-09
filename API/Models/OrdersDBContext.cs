using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalStaffOrdersApp.Models
{
    public class OrdersDBContext:DbContext
    {
        public OrdersDBContext(DbContextOptions<OrdersDBContext> options): base(options)
        {

        }

        public DbSet<OrdersProduct> OrdersProducts { get; set; }

        public DbSet<OrdersStaff> OrdersStaffs { get; set; }

        public DbSet<OrdersCart> OrdersCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdersProduct>().ToTable("OrdersProduct");
            modelBuilder.Entity<OrdersStaff>().ToTable("OrdersStaff");
            modelBuilder.Entity<OrdersCart>().ToTable("OrdersCart");
        }

    }
}
//Kimone Kuppasamy August 2021
//Class to build the DB Context operations