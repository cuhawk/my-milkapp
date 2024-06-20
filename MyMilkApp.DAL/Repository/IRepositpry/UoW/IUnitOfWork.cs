﻿using MyMilkApp.DAL.Data;
using MyMilkApp.DAL.Models;
using MyMilkApp.DAL.Repository.IRepositpry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.DAL.Repository.IRepositpry.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        // Each repository should be a property in the unit of work
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IOriginRepository OriginRepository { get; }
        ICommentRepository CommentRepository { get; }
        IUserRepository UserRepository { get; }
        AppDbContext dbContext { get; }


        // Save changes to the underlying data store
        public Task<int> SaveChangeAsync();
    }
}
