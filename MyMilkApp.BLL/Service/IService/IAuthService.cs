﻿using MyMilkApp.DAL.Models.DTO;
using MyMilkApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMilkApp.DAL.enums;

namespace MyMilkApp.BLL.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDTO> GetUserByIdAsync(string userId);
        Task<ResponseDTO> GetUserByEmailAsync(string email);
        Task<ResponseDTO> RegisterUserAsync(ApplicationUser user, string password, UserRole role);
        Task<ResponseDTO> ValidateUserAsync(ApplicationUser user, string password);
        Task UpdateUserAsync(ApplicationUser user);
    }
}
