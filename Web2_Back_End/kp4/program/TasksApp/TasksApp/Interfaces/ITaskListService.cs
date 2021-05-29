using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksApp.Models;
using TasksApp.ViewModels;

namespace TasksApp.Interfaces
{
    public interface ITaskListService
    {
        IEnumerable<Models.Task> Tasks { get; }

        void AddTask(TaskCreationViewModel taskCreationVm, string authorName);

        void RemoveTask(string taskId);
    }
}
