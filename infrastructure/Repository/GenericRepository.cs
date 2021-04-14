using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using core.Specifications;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;

        }
        public async Task<T> getByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

       
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return  await ApplySpecificatioin(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return  await ApplySpecificatioin(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecificatioin(ISpecification<T> spec){
            var input= _context.Set<T>().AsQueryable();
             return SpecificationEvaluator<T>.getQuery(input ,spec );
        }

        public async Task<int> Count(ISpecification<T> spec)
        {
            return await ApplySpecificatioin(spec).CountAsync(); 
        }
    }
}