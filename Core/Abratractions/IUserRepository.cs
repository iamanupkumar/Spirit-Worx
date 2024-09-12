using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abratractions;

public interface IUserRepository
{
    public Task<bool> CheckDuplicateEmail(int id, string email);
    public Task<bool> RegisterUserAsync(Users model);
    public Task<bool> DeleteUserAsync(int id);
    public Task<bool> UpdateUserAsync(Users model);
    public Task<IEnumerable<Users>> GetAllUsers();
    public Task<Users> GetUserById(int id);
    public Task<Users> LoginAsync(Users model);
}
