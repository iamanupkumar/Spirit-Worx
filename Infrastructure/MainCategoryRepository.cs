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

public class MainCategoryRepository : IMainCategoryRepository
{
    private readonly IDBSession _db;

    public MainCategoryRepository(IDBSession db)
    {
        _db = db;
    }
    public async Task<bool> CreateMainCategoryAsync(MainCatagory mainCatagory)
    {
        var SP = "usp_CreateMaincategory";
        var P = new DynamicParameters();
        P.Add("Name",mainCatagory.Name);
        P.Add("IsActive", mainCatagory.IsActive);
        var rowEffected = await _db.Connection.ExecuteAsync(SP,P,_db.Transaction,null,CommandType.StoredProcedure);
        return rowEffected > 0;
    }

    public async Task<bool> DeleteMainCategoryAsync(int id)
    {
        var SP = "usp_DeleteMaincategory";
        var rowEffected = await _db.Connection.ExecuteAsync(SP,new { @Id =  id },_db.Transaction,null,CommandType.StoredProcedure);
        return rowEffected > 0;
    }    

    public async Task<IEnumerable<MainCatagory>> GetAllMainCategoryAsync()
    {
        var SP = "usp_GetAllMaincategory";
        var rowEffected = await _db.Connection.QueryAsync<MainCatagory>(SP, null, _db.Transaction, null, CommandType.StoredProcedure);
        return rowEffected;
    }
    
    public async Task<MainCatagory> GetMainCatagoryByIdAsync(int id)
    {
        var SP = "usp_GetMaincategoryById";
        var rowEffected = await _db.Connection.QueryFirstOrDefaultAsync<MainCatagory>(SP, new { Id = id }, null, null, CommandType.StoredProcedure);
        return rowEffected;
    }

    public async Task<bool> UpdateMainCategoryAsync(MainCatagory mainCatagory)
    {
        var SP = "usp_UpdateMaincategory";
        var P = new DynamicParameters();
        P.Add("Id", mainCatagory.Id);
        P.Add("Name", mainCatagory.Name);
        P.Add("IsActive", mainCatagory.IsActive);
        var rowEffected = await _db.Connection.ExecuteAsync(SP, P, _db.Transaction, null, CommandType.StoredProcedure);
        return rowEffected > 0;
    }
}
