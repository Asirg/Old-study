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
    public class Answer
    {
        [Key]
        public string AnswerId { get; set; }

        [ForeignKey("Task")]
        public string TaskId { get; set; }

        public string AuthorName { get; set; }

        public string Text { get; set; }

        public DateTime PostingTime { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Task Task { get; set; }
    }
}
