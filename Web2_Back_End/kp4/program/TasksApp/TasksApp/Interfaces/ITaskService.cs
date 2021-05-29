using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksApp.ViewModels;

namespace TasksApp.Interfaces
{
    public interface ITaskService
    {
        Models.Task GetTask(string taskId);

        int GetAnswerAmount(string taskId);

        void AddAnswer(TaskViewModel taskVm, string taskId, string authorName);

        void RemoveAnswer(string answerId);
    }
}
