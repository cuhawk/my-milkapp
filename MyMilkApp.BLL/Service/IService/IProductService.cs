using MyMilkApp.DAL.Models;
using MyMilkApp.DAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.BLL.Service.IService
{
    public interface IProductService
    {
        public Task<List<ProductDTO>> GetAllProductsAsync();
        public Task<ProductDTO> GetProductByIdAsync(int id);
        public Task<ResponseDTO> AddProductAsync(ProductDTO productDTO);
        public Task<ResponseDTO> UpdateProductAsync(int id, ProductDTO productDTO);
        public Task<ResponseDTO> DeleteProductAsync(int id);
        public Task<List<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId);
    }
}
