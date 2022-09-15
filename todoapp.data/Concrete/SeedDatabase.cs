using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todoapp.entity;

namespace todoapp.data.Concrete
{
    public static class SeedDatabase
    {
        private static TaskContext db = new TaskContext();
        public static void Seed()
        {
            if(db.Database.GetPendingMigrations().Count() == 0)
            {
                if(db.Users.Count()==0)
                {
                    db.Users.AddRange(users);
                }

                if(db.Tasks.Count() == 0)
                {
                    db.Tasks.AddRange(tasks);
                }
                
            }
            db.SaveChanges();
        }
        //Used array for example.
        private static Task[] tasks = {
            new Task(){TaskHeader = "SeededTask1", Description="Task1 Seed",isCompleted=false,UserId=1},
            new Task(){TaskHeader = "SeededTask2", Description="Task2 Seed",isCompleted=false,UserId=1},
            new Task(){TaskHeader = "SeededTask2", Description="Task2 Seed",isCompleted=false,UserId=1}
        };
        // Used List for example.
        private static List<User> users = new List<User>() {
            new User(){Name="Umut",Id=1},
            new User(){Name="Batu",Id=2},
            new User(){Name="Salih",Id=3}
        };

    }
}