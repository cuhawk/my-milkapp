using Microsoft.EntityFrameworkCore;
using MyMilkApp.DAL.Data;
using MyMilkApp.DAL.Models;
using MyMilkApp.DAL.Repository.IRepositpry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.DAL.Repository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
