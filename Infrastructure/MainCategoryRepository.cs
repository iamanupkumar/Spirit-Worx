using Core.Abratractions;
using Core.Entities;
using System;
using System.Collections.Generic;
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
    public Task<bool> CreateMainCategoryAsync(MainCatagory mainCatagory)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MainCatagory>> GetAllMainCategory()
    {
        throw new NotImplementedException();
    }

    public Task<MainCatagory> GetMainCatagory(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateMainCategoryAsync(MainCatagory mainCatagory)
    {
        throw new NotImplementedException();
    }
}
