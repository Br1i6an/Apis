using Ejercicio.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ejercicio.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //Define que una columna sea autoincrementable
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Role>()
                .Property(r => r.Id)
                .UseIdentityColumn();

            base.OnModelCreating(modelBuilder);
        }


        // Inyecta la base de datos con los datos cuando se hace la migracion
        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Scrum Master" },
                new Role { Id = 2, RoleName = "Desarrollador" },
                new Role { Id = 3, RoleName = "QA" });
        }
    }
}
        