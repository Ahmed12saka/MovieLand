using MovieLand.Application.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Application.Services.Interfaces.Services
{
    public interface IMovieService
    {
        Task<long?> CreateMovieAsync(
            CreateMovieDTO createMovie);

        Task UpdateMovieAsync(
            long? movieId,
            UpdateMovieDTO  updateMovie);

        Task DeleteMovieAsync(
           long? movieId);

        Task UpdateMoviePriceAsync(
            long? movieId,
            UpdateMoviePriceDTO updateMoviePrice);

        Task<MovieDetailsDTO> GetMovieDetailsAsync(
            long? movieId);

        Task<IEnumerable<MovieShortDTO>> GetMovieListAsync(
            long? categoryId);
    }
}
