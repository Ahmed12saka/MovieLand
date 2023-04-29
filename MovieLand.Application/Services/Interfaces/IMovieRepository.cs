using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using MovieLand.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Application.Services.Interfaces.Services
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetByCategoryAsync(long? categoryId);
        Task<bool> IsMovieUniqueAsync(string name);
        Task<bool> IsMovieUniqueAsync(string name, long? movieId);
    }
}
