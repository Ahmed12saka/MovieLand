using MovieLand.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Application.Services.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> IsCategoryUniqueAsync(
            long? categoryId,
            string name);
    }
}
