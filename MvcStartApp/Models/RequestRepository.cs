using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;
using System;

namespace MvcStartApp.Models
{
    public class RequestRepository : IRequestRepository
    {
        private readonly RequestContext _request;

        public RequestRepository(RequestContext request)
        {
            _request = request;
        }

        public async Task AddRequest(Request request)
        {


            // Добавление информации
            var entry = _request.Entry(request);
            if (entry.State == EntityState.Detached)
                await _request.RequestTable.AddAsync(request);

            // Сохранение изенений
            await _request.SaveChangesAsync();

        }
        public async Task<Request[]> GetRequests()
        {

            return await _request.RequestTable.ToArrayAsync();
        }



    }
}