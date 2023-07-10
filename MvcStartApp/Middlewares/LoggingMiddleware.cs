using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using MvcStartApp.Models;
using System.Linq.Expressions;
using MvcStartApp.Models.Db;
using System.IO;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RequestDelegate _request;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, RequestDelegate request)
        {
            _next = next;
            _request = request;
        }
       
        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context, HttpContext request)
        {
            RequestConsole(request);

            // Передача запроса далее по конвейеру
            await _request.Invoke(request);

            LogConsole(context);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);

        }

        private void LogConsole(HttpContext context)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

        }
        private void RequestConsole(HttpContext request)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{request.Request.Host.Value + request.Request.Path}");

        }

    }
}
