using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BussinesEmployee.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BussinesEmployee.DAL.Database
{
    public class DbContainer :IdentityDbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Country> Country{ get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District{ get; set; }
        public DbContainer(DbContextOptions<DbContainer> options) : base(options)
        {
           
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server = . ; database= EmployeeDatabase ;Integrated Security=true");

        //}

    }




}
