using MyMilkApp.DAL.enums;
using MyMilkApp.DAL.Models;
using MyMilkApp.DAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.DAL.Repository.IRepositpry
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<ResponseDTO> CreateUserAsync(ApplicationUser user, string password);
        Task<ResponseDTO> DeleteUserAsync(string userId, UserStatus status);
    }
}
