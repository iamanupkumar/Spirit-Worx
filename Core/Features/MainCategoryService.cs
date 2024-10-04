using Core.Abratractions;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features;

public class MainCategoryService
{
    private readonly IMainCategoryRepository _main;

    public MainCategoryService(IMainCategoryRepository main)
    {
        _main = main;
    }

    public async Task<IEnumerable<MainCatagory>> GetAllMaincategoryAsync()
    {
        return await _main.GetAllMainCategoryAsync();
    }

    public async Task<MainCatagory> GetMaincategoryByIdAsync(int id)
    {
        return await _main.GetMainCatagoryByIdAsync(id);
    }
    public async Task<bool> CreateMaincategoryAsync(MainCatagory catagory)
    {
        return await _main.CreateMainCategoryAsync(catagory);
    }
    public async Task<bool> DeleteMaincategoryAsync(int id)
    {
        return await _main.DeleteMainCategoryAsync(id);
    }
    public async Task<bool> UpdateMaincategoryAsync(MainCatagory catagory)
    {
        return await _main.UpdateMainCategoryAsync(catagory);
    }    
}
