using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TasksApp.Models
{
    public class Task
    {
        [Key]
        public string TaskId { get; set; }

        [ForeignKey("TaskList")]
        public string ListId { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public string DescriptionText { get; set; }

        public DateTime PostingTime { get; set; }

        public virtual List<Answer> Answers { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual TaskList TaskList { get; set; }
    }
}
