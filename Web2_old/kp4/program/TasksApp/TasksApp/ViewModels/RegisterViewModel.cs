using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TasksApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is not filled")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is not filled")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is not filled")]
        [Compare("Password", ErrorMessage = "Passwords don't match, try again")]
        [DataType(DataType.Password)]
        public string PasswordConfirmed { get; set; }
    }
}
