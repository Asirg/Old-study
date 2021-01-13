using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksApp.Interfaces;
using TasksApp.Data;
using TasksApp.ViewModels;

namespace TasksApp.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly AppDbContext _dbContext;

        public TaskListService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Models.Task> Tasks => _dbContext.Tasks;

        public void AddTask(TaskCreationViewModel taskCreationVm, string authorName)
        {
            if (!string.IsNullOrEmpty(taskCreationVm.TaskName) &&
                !string.IsNullOrEmpty(taskCreationVm.TaskDescription))
            {
                _dbContext.Add(
                    new Models.Task
                    {
                        Name = taskCreationVm.TaskName,
                        DescriptionText = taskCreationVm.TaskDescription,
                        AuthorName = authorName,
                        PostingTime = DateTime.Now
                    });

                _dbContext.SaveChanges();
            }
        }

        public void RemoveTask(string taskId)
        {
            var foundTask = _dbContext.Tasks
                            .SingleOrDefault(task => task.TaskId == taskId);

            if (foundTask != null)
            {
                var taskAnswers = _dbContext.Answers
                                 .Where(answer => answer.TaskId == taskId);

                if (taskAnswers != null)
                {
                    _dbContext.Answers.RemoveRange(taskAnswers);
                }

                _dbContext.Tasks.Remove(foundTask);

                _dbContext.SaveChanges();
            }
        }
    }
}
