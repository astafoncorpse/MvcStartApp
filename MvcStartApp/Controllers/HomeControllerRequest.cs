using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcStartApp.Models.Db;
using MvcStartApp.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using System;

namespace MvcStartApp.Controllers
{
    public class HomeControllerRequest : Controller
    {
        // ссылка на репозиторий

        private readonly IRequestRepository _request;

        private readonly ILogger<HomeControllerRequest> _logger;

        // Также добавим инициализацию в конструктор
        public HomeControllerRequest(ILogger<HomeControllerRequest> logger, IRequestRepository request)
        {
            _logger = logger;
            _request = request;

        }
        // Сделаем метод асинхронным
        public async Task<IActionResult> Index()
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

