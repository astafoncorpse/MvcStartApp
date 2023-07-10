using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using MvcStartApp.Models;
using System.Threading.Tasks;
using System;
using AspNetCore;

namespace MvcStartApp.Controllers
{
    public class LogsCotroller : Controller
    {
        private readonly IRequestRepository _request;

        public LogsCotroller(IRequestRepository request)
        {
            _request = request;
        }

     
        public async Task<IActionResult> Logs()
        {
            var logs = await _request.GetRequests();
            return View(logs);
        }


    }
}
