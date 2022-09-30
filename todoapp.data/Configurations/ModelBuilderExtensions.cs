using System;
using System.Collections.Generic;
using System.Linq;

//using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todoapp.entity;

namespace todoapp.data.Configurations
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Task>().HasData(
                new Task(){TaskHeader = "SeededTask1", Description="Task1 Seed",isCompleted=false,UserId="1"},
                new Task(){TaskHeader = "SeededTask2", Description="Task2 Seed",isCompleted=false,UserId="1"},
                new Task(){TaskHeader = "SeededTask2", Description="Task2 Seed",isCompleted=false,UserId="1"}
        
            );
        }
    }
}