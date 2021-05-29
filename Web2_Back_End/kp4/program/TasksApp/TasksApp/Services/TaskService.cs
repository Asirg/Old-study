using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksApp.Interfaces;
using TasksApp.Models;
using TasksApp.Data;
using TasksApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TasksApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _dbContext;

        public TaskService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Models.Task GetTask(string taskId)
        {
            return _dbContext.Tasks
                   .Include("Answers")
                   .SingleOrDefault(task => task.TaskId == taskId);
        }

        public int GetAnswerAmount(string taskId)
        {
            var answers = _dbContext.Answers
                          .Where(answer => answer.TaskId == taskId).ToList();

            if (answers != null)
                return answers.Count;
            else
                return 0;
        }

        public void AddAnswer(TaskViewModel taskVm, string taskId, string authorName)
        {
            if (!string.IsNullOrEmpty(taskVm.AnswerText))
            {
                _dbContext.Add(
                    new Answer
                    {
                        TaskId = taskId,
                        Text = taskVm.AnswerText,
                        AuthorName = authorName,
                        PostingTime = DateTime.Now
                    });

                _dbContext.SaveChanges();
            }
        }

        public void RemoveAnswer(string answerId)
        {
            var foundAnswer = _dbContext.Answers
                              .SingleOrDefault(answer => answer.AnswerId == answerId);

            if (foundAnswer != null)
            {
                _dbContext.Answers.Remove(foundAnswer);

                _dbContext.SaveChanges();
            }
        }
    }
}
