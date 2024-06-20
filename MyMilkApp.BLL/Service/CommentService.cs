﻿using AutoMapper;
using MyMilkApp.BLL.Service.IService;
using MyMilkApp.DAL.Migrations;
using MyMilkApp.DAL.Models;
using MyMilkApp.DAL.Models.DTO;
using MyMilkApp.DAL.Repository.IRepositpry;
using MyMilkApp.DAL.Repository.IRepositpry.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.BLL.Service
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CommentDTO>> GetAllCommentAsync()
        {
            var commentGetAll = await _unitOfWork.CommentRepository.GetAllAsync();
            var commentMapper = _mapper.Map<List<CommentDTO>>(commentGetAll);
            return commentMapper;
        }

        public async Task<CommentDTO> GetCommentByIdAsync(int id)
        {
            var commentFound = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            if (commentFound == null)
            {
                return null;
            }
            var commentMapper = _mapper.Map<CommentDTO>(commentFound);
            return commentMapper;

        }

        public async Task<ResponseDTO> AddCommentAsync(CommentDTO commentDTO)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(commentDTO.productId);
            if (product == null)
            {
                // Handle scenario where product is not found
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Product not found",
                };
            }

            var commentObj = _mapper.Map<Comment>(commentDTO);

            commentObj.Product = product;

            await _unitOfWork.CommentRepository.AddAsync(commentObj);
            await _unitOfWork.SaveChangeAsync();

            var response = new ResponseDTO
            {
                IsSucceed = true,
                Message = "Comment added successfully",
            };
            return response;
        }

        public async Task<ResponseDTO> UpdateCommentAsync(int id, CommentDTO commentDTO)
        {
            var commentUpdate = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            if (commentUpdate != null)
            {
                commentUpdate = _mapper.Map(commentDTO, commentUpdate);
                await _unitOfWork.CommentRepository.UpdateAsync(commentUpdate);
                var result = await _unitOfWork.SaveChangeAsync();
                if (result > 0)
                {
                    return new ResponseDTO
                    {
                        IsSucceed = true,
                        Message = "Comment update successfully!"
                    };
                }
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = "Comment update failed!"
                };
            }
            return new ResponseDTO
            {
                IsSucceed = false,
                Message = "Comment not found!"
            };
        }

        public async Task<ResponseDTO> DeleteCommentAsync(int id)
        {
            var deleteComment = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            if (deleteComment != null)
            {
                await _unitOfWork.CommentRepository.DeleteAsync(id);
                await _unitOfWork.SaveChangeAsync();

                return new ResponseDTO
                {
                    IsSucceed = true,
                    Message = "Comment deleted successfully"
                };
            }
            else
            {
                return new ResponseDTO
                {
                    IsSucceed = false,
                    Message = $"Comment with ID {id} not found"
                };
            }

        }
    }
}
