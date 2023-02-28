using CloudCustomer.API.Data;
using CloudCustomer.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudCustomer.API.Services
{
    public interface IUsersService
    {
        public Task<List<User>> GetAllUsers();
    }
    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;
        private readonly yhApiContext _context;
        public UsersService(
            HttpClient httpClient,
            yhApiContext context
        )
        {
            _httpClient = httpClient;
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var userResponse = await _httpClient.GetAsync("https://example.com");
            var users = await _context.Users.Take(10).ToListAsync();
            return users;
        }
    }
}
