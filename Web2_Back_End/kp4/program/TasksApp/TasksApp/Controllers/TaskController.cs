using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasksApp.Interfaces;
using TasksApp.ViewModels;
using Newtonsoft.Json;

namespace TasksApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ICacheService _cacheService;

        public TaskController(ITaskService taskService, ICacheService cacheService)
        {
            _taskService = taskService;
            _cacheService = cacheService;
        }

        [HttpGet("/task/{taskId}")]
        public async Task<IActionResult> Index(string taskId)
        {
            string cachedTask = await _cacheService.GetCacheValueAsync("task" + taskId);
            Models.Task task = null;

            if (string.IsNullOrEmpty(cachedTask))
            {
                task = _taskService.GetTask(taskId);
                task.Answers = task.Answers.OrderByDescending(answer => answer.PostingTime).ToList();

                string taskString = JsonConvert.SerializeObject(task);

                await _cacheService.SetCacheValueAsync("task" + taskId, taskString);
            }
            else
            {
                string taskString = await _cacheService.GetCacheValueAsync("task" + taskId);

                task = JsonConvert.DeserializeObject<Models.Task>(taskString);
            }

            var taskVm = new TaskViewModel
            {
                Task = task,
                AnswersAmount = _taskService.GetAnswerAmount(taskId)
            };

            return View(taskVm);
        }

        [Authorize]
        [HttpPost]
        public async Task<RedirectToActionResult> AddAnswer(TaskViewModel taskVm, string taskId, string authorName)
        {
            _taskService.AddAnswer(taskVm, taskId, authorName);
            await _cacheService.SetCacheValueAsync("task" + taskId, "");

            return RedirectToAction("Index", "Task", new { taskId });
        }

        [Authorize]
        [HttpGet("/task/remove-answer/{answerId}/{taskId}")]
        public async Task<RedirectToActionResult> RemoveAnswer(string answerId, string taskId)
        {
            _taskService.RemoveAnswer(answerId);
            await _cacheService.SetCacheValueAsync("task" + taskId, "");

            return RedirectToAction("Index", "Task", new { taskId });
        }
    }
}
