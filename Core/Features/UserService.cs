using Core.Abratractions;
using Core.Entities;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> RegisterUserAsync(Users users)
    {
        return await _userRepository.RegisterUserAsync(users);
    }
    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }
    public async Task<Users> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetUserById(id);
    }
    public async Task<IEnumerable<Users>> GetAllUserAsync()
    {
        return await _userRepository.GetAllUsers();
    }
    public async Task<bool> UpdateUserAsync(Users users)
    {
        return await _userRepository.UpdateUserAsync(users);
    }

    public async Task<UserWithToken> LoginAsync(string emailId, string password)
    {
        var loginInfo = await _userRepository.LoginAsync(emailId,password);
        if (loginInfo != null)
        {
            loginInfo.Token = CommonHelper.GenerateJwtToken(loginInfo.UserId);
        }
        return loginInfo;
    }
}
