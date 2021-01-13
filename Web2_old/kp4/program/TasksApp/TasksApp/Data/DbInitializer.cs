using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksApp.Models;

namespace TasksApp.Data
{
    public class DbInitializer
    {
        public void InitializeTasks(AppDbContext dbContext)
        {
            dbContext.Answers.RemoveRange(dbContext.Answers);
            dbContext.Tasks.RemoveRange(dbContext.Tasks);
            dbContext.TaskLists.RemoveRange(dbContext.TaskLists);

            dbContext.SaveChanges();

            var tasks = new List<Models.Task>
            {
                new Models.Task
                {
                    Name = "name",
                    AuthorName = "author",
                    DescriptionText = "text"
                },
                new Models.Task
                {
                    Name = "name",
                    AuthorName = "author",
                    DescriptionText = "text"
                }
            };

            dbContext.AddRange
                (
                    new TaskList
                    {
                        Tasks = tasks
                    }
                );

            dbContext.SaveChanges();
        }
    }
}
