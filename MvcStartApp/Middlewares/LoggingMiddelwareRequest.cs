using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddelwareRequest
    {

        private readonly RequestDelegate _request;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddelwareRequest(RequestDelegate request)
        {
            _request = request;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext request)
        {

            LogConsole(request);

            // Передача запроса далее по конвейеру
            await _request.Invoke(request);

        }

        private void LogConsole(HttpContext request)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{request.Request.Host.Value + request.Request.Path}");
        }
    }
}
