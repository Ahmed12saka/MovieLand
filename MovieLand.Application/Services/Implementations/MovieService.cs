using AutoMapper;
using Microsoft.Build.Tasks;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using MovieLand.Application.Models;
using MovieLand.Application.Services.DTO;
using MovieLand.Application.Services.Interfaces.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Application.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        public MovieService(
            IMapper mapper,
            IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<long?> CreateMovieAsync(
            CreateMovieDTO createMovie)
        {
            var price = new Price(
                createMovie.PriceAmount,
                createMovie.PriceCurrency);

            var movie = Movie.Create(
                createMovie.Name,
                createMovie.Description,
                createMovie.CategoryId,
                createMovie.Quanitity,
                price);

            var movieId = await _movieRepository.SaveAsync(movie);

            return movieId;
        }
        public async Task DeleteMovieAsync(
            long? movieId)
        {
            if (movieId is null)
            {
                throw new ArgumentNullException(
                    nameof(movieId),
                    "Movie id is requred");
            }
            var movie = await _movieRepository.GetAsync(
               movieId);

            if (movie is null)
            {
                throw new ArgumentException(
                    $"Movie with id {movieId} does not exist",
                    nameof(movie));
            }

            await _movieRepository.DeleteAsync(movie);
        }
        public async Task UpdateMovieAsync(
           long? movieId,
           UpdateMovieDTO updateMovie)
        {
            if (movieId is null)
            {
                throw new ArgumentNullException(
                    nameof(movieId),
                    "Movie id is requred");
            }
            var movie = await _movieRepository.GetAsync(
                movieId);

            if (movie is null)
            {
                throw new ArgumentException(
                    $"Movie with id {movieId} does not exist",
                    nameof(movie));
            }
           

            movie.Update(
            updateMovie.Name,
            updateMovie.Description,
            updateMovie.Quanitity);

            await _movieRepository.UpdateAsync(movie);
        }

        public async Task UpdateMoviePriceAsync(
       long? movieId,
       UpdateMoviePriceDTO updateMoviePrice)
        {
            if (movieId is null)
            {
                throw new ArgumentNullException(
                    nameof(movieId),
                    "Movie id is requred");
            }

            var movie = await _movieRepository.GetAsync(
                movieId);

            if (movie is null)
            {
                throw new ArgumentException(
                    $"Movie wit id {movieId} does not exist",
                    nameof(movie));
            }

            var newPrice = new Price(
                updateMoviePrice.PriceAmount,
                updateMoviePrice.PriceCurrency);

            movie.ChangePrice(newPrice);

            await _movieRepository.UpdateAsync(movie);
        }
        public async Task<MovieDetailsDTO> GetMovieDetailsAsync(
              long? movieId)
        {
            if (movieId is null)
            {
                throw new ArgumentNullException(
                   nameof(movieId),
                  "Movie id is requred");
            }
            var movie = await _movieRepository.GetAsync(
                movieId);

            if (movie is null)
            {
                throw new ArgumentException(
                    $"Movie wit id {movieId} does not exist",
                    nameof(movie));
            }

            return _mapper.Map<MovieDetailsDTO>(movie);
        }

        public async Task<IEnumerable<MovieShortDTO>> GetMovieListAsync(
            long? categoryId)
        {
            var movies = categoryId == null
                ? await _movieRepository.GetAsync()
                : await _movieRepository.GetByCategoryAsync(categoryId);

            return _mapper.Map<IEnumerable<MovieShortDTO>>(movies);
        }

    }

    
}


