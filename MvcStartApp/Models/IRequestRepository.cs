using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Models
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequests();
    }
}
