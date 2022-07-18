using System;
using Microsoft.EntityFrameworkCore;
using MCC67.Models;

namespace MCC67.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> contextOptions) : base(contextOptions)
        {

        }
        public DbSet<Produk> Produk { get; private set; }
        public DbSet<Supplier> Supplier { get; private set; }
        public DbSet<Account> Account { get; private set; }
        public DbSet<User> User { get; private set; }
        public DbSet<Employee> Employee { get; private set; }
        public DbSet<Role> Role { get; private set; }
        public DbSet<Role_User> Role_User { get; private set; }
    }
}
