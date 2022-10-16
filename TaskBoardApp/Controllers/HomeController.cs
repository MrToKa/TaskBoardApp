using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public HomeController(TaskBoardAppDbContext context)
        {
            this.data = context;
        }


        public IActionResult Index()
        {
            var taskBoards = this.data.Boards.Select(b => b.Name).Distinct();

            var taskCounts = new List<HomeBoardModel>();

            foreach (var boardName in taskBoards)
            {
                var tasksInBoard = this.data.Tasks.Count(t => t.Board.Name == boardName);

                taskCounts.Add(new HomeBoardModel()
                {
                    BoardName = boardName,
                    TasksCount = tasksInBoard
                });
            }

            var userTasksCount = -1;

            if (User.Identity is {IsAuthenticated: true})
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                userTasksCount = data.Tasks.Count(t => t.OwnerId == currentUserId);
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = this.data.Tasks.Count(),
                BoardsWithTasksCount = taskCounts,
                UserTasksCount = userTasksCount
            };

            return View(homeModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}