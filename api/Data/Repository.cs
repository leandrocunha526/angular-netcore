using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class Repository : IRepository
    {
        public ApplicationDbContext _context { get; }
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<Product[]> GetAllProductsAsync()
        {
            IQueryable<Product> query = _context.Products;
            query = query.AsNoTracking().OrderBy(product => product.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Product> GetProductAsyncById(int ProductId)
        {
            IQueryable<Product> query = _context.Products;
            query = query.AsNoTracking().OrderBy(product => product.Id).Where(product => product.Id == ProductId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
