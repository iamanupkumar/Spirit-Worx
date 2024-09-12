using Core.Abratractions;
using Core.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly IDBSession _db;

    public UserRepository(IDBSession db)
    {
        _db = db;
    }
    public Task<bool> CheckDuplicateEmail(int id, string email)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var SP = "usp_DeleteUser";
        var rowEffected = await _db.Connection.ExecuteAsync(SP, new { @Id = id }, _db.Transaction, null, CommandType.StoredProcedure);
        return rowEffected > 0;
    }

    public async Task<Users> GetUserById(int id)
    {
        var SP = "usp_GetUserById";
        var rowEffected = await _db.Connection.QueryFirstOrDefaultAsync<Users>(SP, new { @Id = id }, _db.Transaction, null, CommandType.StoredProcedure);
        return rowEffected;
    }

    public async Task<IEnumerable<Users>> GetAllUsers()
    {
        var SP = "usp_GetAllUsers";
        var rowEffected = await _db.Connection.QueryAsync<Users>(SP,null,_db.Transaction,null,CommandType.StoredProcedure);
        return rowEffected;
    }

    public Task<Users> LoginAsync(Users model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RegisterUserAsync(Users model)
    {
        var SP = "usp_RegisterUser";
        var P = new DynamicParameters();
        P.Add("FirstName", model.FirstName);
        P.Add("LastName", model.LastName);
        P.Add("EmailId", model.EmailId);
        P.Add("MobileNo",model.MobileNo);
        P.Add("Password", model.Password);
        P.Add("Role", model.Role);
        var rowEffected = await _db.Connection.ExecuteAsync(SP,P,_db.Transaction,null, CommandType.StoredProcedure);
        return rowEffected > 0;
    }

    public async Task<bool> UpdateUserAsync(Users model)
    {
        var SP = "usp_UpdateUser";
        var P = new DynamicParameters();
        P.Add("Id", model.Id);
        P.Add("FirstName", model.FirstName);
        P.Add("LastName", model.LastName);
        P.Add("EmailId", model.EmailId);
        P.Add("MobileNo", model.MobileNo);
        P.Add("Password", model.Password);
        P.Add("Role", model.Role);
        var rowEffected = await _db.Connection.ExecuteAsync(SP, P,_db.Transaction,null,CommandType.StoredProcedure);
        return rowEffected > 0;
    }
}
