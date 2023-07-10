using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcStartApp.Models;
using MvcStartApp.Models.Db;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class HomeController : Controller
    {
        // ссылка на репозиторий
        private readonly IBlogRepository _repo;
        private readonly IRequestRepository _request;
        private readonly ILogger<HomeController> _logger;

        // Также добавим инициализацию в конструктор
        public HomeController(ILogger<HomeController> logger, IBlogRepository repo, IRequestRepository request)
        {
            _logger = logger;
            _repo = repo;
            _request = request;

        }
      

        // Сделаем метод асинхронным
        public async Task<IActionResult> Index()
        {
            // Добавим создание нового пользователя
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Roman",
                LastName = "Brazhnik",
                JoinDate = DateTime.Now
            };

            // Добавим в базу
            await _repo.AddUser(newUser);

            // Выведем результат
            Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added on {newUser.JoinDate}");

            return View();

        }
        public async Task<IActionResult> IndexLogs()
        {
            // Добавим новую информацию

            var newRequest = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = "REQUEST"

            };
            await _request.AddRequest(newRequest);

            return View();

        }
       

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Authors()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }
        public async Task<IActionResult> Logs()
        {
            var logs = await _request.GetRequests();
            return View(logs);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
