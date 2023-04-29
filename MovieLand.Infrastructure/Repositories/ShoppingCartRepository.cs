using Microsoft.EntityFrameworkCore;
using MovieLand.Application.Models;
using MovieLand.Application.Services.Interfaces;
using MovieLand.Infrastructure.Database.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly DatabaseContext _context;

        public ShoppingCartRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(ShoppingCart entity)
        {
            _context.ShoppingCarts.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<ShoppingCart> GetAsync(long? id)
        {
            return await _context.ShoppingCarts.AsQueryable()
                .Include(c => c.Items).ThenInclude(c => c.Movie).ThenInclude(c => c.Price)
                .Where(c => c.Id == id)
                .SingleAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> GetAsync()
        {
            return await _context.ShoppingCarts.AsQueryable()
                .Include(c => c.Items).ThenInclude(c => c.Movie).ThenInclude( c=> c.Price)
                .ToListAsync();
        }

        public async Task<long?> SaveAsync(ShoppingCart entity)
        {
            await _context.ShoppingCarts.AddAsync(entity);
            return entity.Id;
        }

        public Task UpdateAsync(ShoppingCart entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }

        public Task<ShoppingCart> GetPending()
        {
            return _context.ShoppingCarts.AsQueryable()
                .Include(c => c.Items).ThenInclude(c => c.Movie).ThenInclude(c => c.Price)
                .Where(c => c.Status == ShoppingCartStatus.Pending)
                .SingleOrDefaultAsync();
        }
    }
}
