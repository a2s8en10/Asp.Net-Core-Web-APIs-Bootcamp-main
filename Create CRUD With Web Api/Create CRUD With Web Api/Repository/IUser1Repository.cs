using Create_CRUD_With_Web_Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Create_CRUD_With_Web_Api.Repository
{
    public interface IUser1Repository
    {
        Task<List<User1>> GetAllUsersAsync();
        Task<User1> GetUserByIdAsync(int userId);
        Task<int> AddNewUserAsync(User1 user1);
    }
}
