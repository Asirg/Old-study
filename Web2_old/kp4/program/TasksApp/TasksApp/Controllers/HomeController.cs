using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasksApp.Interfaces;
using TasksApp.ViewModels;

namespace TasksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskListService _taskListService;
        private readonly ICacheService _cacheService;

        public HomeController(ITaskListService taskListService, ICacheService cacheService)
        {
            _taskListService = taskListService;
            _cacheService = cacheService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var taskListVm = new TaskListViewModel
            {
                TaskList = _taskListService.Tasks
            };

            return View(taskListVm);
        }

        [Authorize]
        [HttpPost]
        public RedirectToActionResult AddTask(TaskCreationViewModel taskCreationVm, string authorName)
        {
            _taskListService.AddTask(taskCreationVm, authorName);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet("/remove-task/{taskId}")]
        public RedirectToActionResult RemoveTask(string taskId)
        {
            _taskListService.RemoveTask(taskId);
            _cacheService.RemoveCacheKeyAsync("task" + taskId);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
