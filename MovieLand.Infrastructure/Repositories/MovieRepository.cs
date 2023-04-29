using Microsoft.EntityFrameworkCore;
using MovieLand.Application.Models;
using MovieLand.Application.Services.Interfaces.Services;
using MovieLand.Infrastructure.Database.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DatabaseContext _context;

        public MovieRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(Movie entity)
        {
            _context.Movies.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<Movie> GetAsync(long? id)
        {
            return await _context.Movies.AsQueryable()
                .Include(c => c.Price)
                .Include(c => c.Category)
                .Where(c => c.Id == id)
                .SingleAsync();
        }

        public async Task<IEnumerable<Movie>> GetAsync()
        {
            return await _context.Movies.AsQueryable()
                .Include(c => c.Price)
                .Include(c => c.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetByCategoryAsync(long? categoryId)
        {
            return await _context.Movies.AsQueryable()
                .Include(c => c.Price)
                .Include(c => c.Category)
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<bool> IsMovieUniqueAsync(string name)
        {
            var exists = await _context.Movies.AsQueryable()
                .Where(e => e.Name == name)
                .Select(e => true)
                .AnyAsync();

            return !exists;
        }

        public async Task<bool> IsMovieUniqueAsync(
            string name,
            long? productId)
        {
            var exists = await _context.Movies.AsQueryable()
                .Where(e => e.Name == name)
                .Where(e => e.Id != productId)
                .Select(e => true)
                .AnyAsync();

            return !exists;
        }

        public async Task<long?> SaveAsync(Movie entity)
        {
            var data = await _context.Movies.AddAsync(entity);

            return entity.Id;
        }

        public Task UpdateAsync(Movie entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
