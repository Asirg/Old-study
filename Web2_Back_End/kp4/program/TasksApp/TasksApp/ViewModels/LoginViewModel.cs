using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TasksApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Name is not filled")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is not filled")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
