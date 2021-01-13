using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TasksApp.ViewModels;
using TasksApp.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace TasksApp.Controllers
{
    [Authorize]
    public class TaskCreationController : Controller
    {
        [HttpGet("/task-creation/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
