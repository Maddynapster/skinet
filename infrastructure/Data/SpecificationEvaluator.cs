using System.Linq;
using core.Entities;
using core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity: BaseEntity
    {
        public static IQueryable<TEntity> getQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec){
            var query= inputQuery;
            if(spec.Criteria != null)
            {
                query= query.Where(spec.Criteria);
            }
            if(spec.OrderBy != null)
            {
                query= query.OrderBy(spec.OrderBy);
            }
            if(spec.OrderByDesc != null)
            {
                query= query.OrderByDescending(spec.OrderByDesc);
            }
            if(spec.Includes !=null){
                 query= spec.Includes.Aggregate(query, (current,include) => current.Include(include) );
            }

            if(spec.IsPaginfEnable){
                query= query.Skip(spec.Skip).Take(spec.Take);
            }
               
            return query;
        }
    }
}