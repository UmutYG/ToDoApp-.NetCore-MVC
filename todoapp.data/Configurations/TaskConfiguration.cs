using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todoapp.entity;
//sing System.Threading.Tasks;

namespace todoapp.data.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t=>t.TaskId);
            builder.Property(t=>t.TaskHeader).IsRequired().HasMaxLength(100);

            // builder.Property(t=>t.DateAdded).HasDefaultValueSql("getdate()"); => mssql
            // builder.Property(t=>t.DateAdded).HasDefaultValueSql("date('now')"); => sqlite

            // Moved to extension folder.
                // builder.HasData(
                //     new Task(){TaskHeader = "SeededTask1", Description="Task1 Seed",isCompleted=false,UserId="1"},
                //     new Task(){TaskHeader = "SeededTask2", Description="Task2 Seed",isCompleted=false,UserId="1"},
                //     new Task(){TaskHeader = "SeededTask2", Description="Task2 Seed",isCompleted=false,UserId="1"}
                // );
        }
    }
}