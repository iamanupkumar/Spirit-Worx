using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abratractions;

public interface IMainCategoryRepository
{
    public Task<bool> CreateMainCategoryAsync(MainCatagory mainCatagory);
    public Task<bool> UpdateMainCategoryAsync(MainCatagory mainCatagory);
    public Task<bool> DeleteMainCategoryAsync(int id);
    public Task<IEnumerable<MainCatagory>> GetAllMainCategoryAsync();
    public Task<MainCatagory> GetMainCatagoryByIdAsync(int id);    
}
