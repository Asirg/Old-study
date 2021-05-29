using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksApp.Models;

namespace TasksApp.ViewModels
{
    public class TaskViewModel
    {
        public Models.Task Task { get; set; }

        public int AnswersAmount { get; set; }

        public string AnswerText { get; set; }
    }
}
