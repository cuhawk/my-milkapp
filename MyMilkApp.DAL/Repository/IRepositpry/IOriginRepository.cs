using MyMilkApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.DAL.Repository.IRepositpry
{
    public interface IOriginRepository : IGenericRepository<Origin>
    {
        Task<IEnumerable<Origin>> GetAllOriginsAsync();
        Task<Origin> GetOriginByIdAsync(int originId);
    }
}
