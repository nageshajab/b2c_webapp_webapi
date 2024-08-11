using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListService.Models;

namespace TodoListClient.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAsync();

        Task<User> GetAsync(string id);

        Task DeleteAsync(string id);

        Task<User> EditAsync(User todo);
    }
}
