﻿using MyMilkApp.DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMilkApp.DAL.Models.DTO;

namespace MyMilkApp.BLL.Service.IService
{
    public interface ICommentService
    {
        public Task<ResponseDTO> AddCommentAsync(CommentDTO commentDTO);
        public Task<CommentDTO> GetCommentByIdAsync(int id);
        public Task<List<CommentDTO>> GetAllCommentAsync();
        public Task<ResponseDTO> UpdateCommentAsync(int id, CommentDTO commentDTO);
        public Task<ResponseDTO> DeleteCommentAsync(int id);
    }
}
