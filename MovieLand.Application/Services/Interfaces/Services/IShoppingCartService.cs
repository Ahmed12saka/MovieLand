using MovieLand.Application.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Application.Services.Interfaces.Services
{
    public interface IShoppingCartService
    {
        Task<long?> CreateShoppingCart(
            long? movieId,
            int quantity);

        Task<ShoppingCartDTO> GetShoppingCartDetailsAsync(
            long? shoppingCartId);

        Task<IEnumerable<ShoppingCartShortDTO>> GetShoppingCartListAsync();
    }
}
