using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TasksApp.Models
{
    public class TaskList
    {
        [Key]
        public string ListId { get; set; }

        public virtual List<Task> Tasks { get; set; }
    }
}
