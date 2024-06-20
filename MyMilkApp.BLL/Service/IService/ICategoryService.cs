using MyMilkApp.DAL.Models.DTO;
using MyMilkApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.BLL.Service.IService
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTO>> GetAllCategorysAsync();
        public Task<CategoryDTO> GetCategoryByIdAsync(int id);
        public Task<ResponseDTO> AddCategoryAsync(CategoryDTO categoryDTO);
        public Task<ResponseDTO> UpdateCategoryAsync(int id, CategoryDTO categoryDTO);
        public Task<ResponseDTO> DeleteCategoryAsync(int id);
    }
}
