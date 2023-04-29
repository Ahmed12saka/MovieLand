using AutoMapper;
using MovieLand.Application.Models;
using MovieLand.Application.Services.DTO;
using MovieLand.Application.Services.Interfaces.Services;
using MovieLand.Application.Services.Interfaces;
using MovieLand.Application.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Application.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(
            IMapper mapper,
            IMovieRepository movieRepository,
            IShoppingCartRepository shoppingCartRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<long?> CreateShoppingCart(long? movieId, int quantity)
        {
            if (movieId is null || movieId <= 0)
            {
                throw new ArgumentException(
                    $"Invalid product id {movieId}");
            }

            var movie = await _movieRepository.GetAsync(movieId);

            if (movie == null)
            {
                throw new ArgumentException(
                    $"Invalid product id {movieId}. " +
                    $"Product not found.");
            }

            var shoppingCart = await _shoppingCartRepository.GetPending();

            if (shoppingCart is null)
            {
                shoppingCart = ShoppingCart.Create(
                    movie.Price.Currency);
            }

            shoppingCart.AddItem(
                movie,
                quantity);

            if (shoppingCart.Id is null)
            {
                await _shoppingCartRepository.SaveAsync(shoppingCart);
            }
            else
            {
                await _shoppingCartRepository.UpdateAsync(shoppingCart);
            }

            return shoppingCart.Id;
        }

        public async Task<ShoppingCartDTO> GetShoppingCartDetailsAsync(long? shoppingCartId)
        {
            if (shoppingCartId is null || shoppingCartId <= 0)
            {
                throw new ArgumentException(
                    $"Invalid shopping cart id {shoppingCartId}.");
            }

            var shoppingCart = await _shoppingCartRepository.GetAsync(shoppingCartId);

            if (shoppingCart is null)
            {
                throw new ArgumentException(
                    $"Invalid shopping cart id {shoppingCartId}. " +
                    $"Shopping cart not found.");
            }

            return _mapper.Map<ShoppingCartDTO>(shoppingCart);
        }

        public async Task<IEnumerable<ShoppingCartShortDTO>> GetShoppingCartListAsync()
        {
            var shoppingCarts = await _shoppingCartRepository.GetAsync();

            return _mapper.Map<IEnumerable<ShoppingCartShortDTO>>(shoppingCarts);
        }
    }
}
