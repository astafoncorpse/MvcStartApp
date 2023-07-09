using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;
using System;

namespace MvcStartApp.Models
{
    public class RequestRepository : IRequestRepository
    {
        // ссылка на контекст
        private readonly RequestContext _repo;

        // Метод-конструктор для инициализации
        public RequestRepository(RequestContext repo)
        {
            _repo = repo;
        }

        public async Task AddRequest(Request request)
        {
            // Добавление информации
            var entry = _repo.Entry(request);
            if (entry.State == EntityState.Detached)
                await _repo.RequestTable.AddAsync(request);

            // Сохранение изенений
            await _repo.SaveChangesAsync();
        }
       
    }
}
