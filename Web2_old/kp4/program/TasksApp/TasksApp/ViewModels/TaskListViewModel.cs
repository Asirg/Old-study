using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksApp.ViewModels
{
    public class TaskListViewModel
    {
        public IEnumerable<Models.Task> TaskList { get; set; }
    }
}
