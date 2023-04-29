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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;

        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(Category entity)
        {
            _context.Categories.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<Category> GetAsync(long? id)
        {
            return await _context.Categories.AsQueryable()
                .Where(c => c.Id == id)
                .SingleAsync();
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await _context.Categories.AsQueryable()
                .ToListAsync();
        }

        public async Task<bool> IsCategoryUniqueAsync(
            long? categoryId,
            string name)
        {
            var exists = await _context.Categories.AsQueryable()
                .Where(c => c.Name == name)
                .Where(c => c.Id != categoryId)
                .Select(c => c.Id)
                .AnyAsync();

            return !exists;
        }

        public async Task<long?> SaveAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            return entity.Id;
        }

        public Task UpdateAsync(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }

}
