using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using todoapp.data.Configurations;
using todoapp.entity;

namespace todoapp.data.Concrete
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            
        }
        public DbSet<Task> Tasks { get; set; }


        // Moved connectionString to appSettings.js
            // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            // {
            
            //     optionsBuilder.UseSqlite("Data Source = taskDb");
            // }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent Api Configurations.
            modelBuilder.ApplyConfiguration(new TaskConfiguration());

            // Used Extension Method That We Created.
            modelBuilder.Seed();
        }


    }
}