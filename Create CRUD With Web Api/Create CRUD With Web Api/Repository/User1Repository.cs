using Create_CRUD_With_Web_Api.Data;
using Create_CRUD_With_Web_Api.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_CRUD_With_Web_Api.Repository
{
    public class User1Repository : IUser1Repository
    {
        private readonly UserContext _Context;

        public User1Repository(UserContext context)
        {
            _Context = context;
        }

        public async Task<List<User1>> GetAllUsersAsync()
        {
            var record = await _Context.User1.Select(x => new User1()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address
            }).ToListAsync();

            return record;
        }

        public async Task<User1> GetUserByIdAsync(int userId)
        {
            var record = await _Context.User1.Where(x => x.Id == userId).Select(x => new User1()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address
            }).FirstOrDefaultAsync();

            return record;
        }

        public async Task<int> AddNewUserAsync(User1 user1)
        {
            var user = new User1()
            {
                Name = user1.Name,
                Email = user1.Email,
                Password = user1.Password,
                PhoneNumber = user1.PhoneNumber,
                Address = user1.Address
            };
            _Context.User1.Add(user);
            await _Context.SaveChangesAsync();

            return user.Id;
        }


    }
}
