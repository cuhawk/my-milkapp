using MyMilkApp.DAL.Models.DTO;
using MyMilkApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMilkApp.DAL.enums;

namespace MyMilkApp.DAL.Repository.IRepositpry
{
    public interface IAuthRepository
    {
        Task<ResponseDTO> GetUserByIdAsync(string userId);
        Task<ResponseDTO> GetUserByEmailAsync(string email);
        Task<ResponseDTO> CreateUserAsync(ApplicationUser user, string password);
        Task<ResponseDTO> CheckPasswordAsync(ApplicationUser user, string password);
        Task<ResponseDTO> AddUserToRoleAsync(ApplicationUser user, UserRole role);
        Task UpdateUserAsync(ApplicationUser user);
    }
}
