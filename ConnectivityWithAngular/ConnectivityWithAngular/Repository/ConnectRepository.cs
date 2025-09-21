using ConnectivityWithAngular.Data;
using ConnectivityWithAngular.Model;
using Microsoft.EntityFrameworkCore;

namespace ConnectivityWithAngular.Repository
{
    public class ConnectRepository : IConnectRepository
    {
        private readonly ConnectContext _context;
        public ConnectRepository(ConnectContext context)
        {
            _context = context;
        }

        public async Task<List<ConnectModel>> GetAllMassageAsync()
        {
            var result = await _context.Connects.ToListAsync();
            return result;
        }
    }
} 
