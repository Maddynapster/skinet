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
            if(spec.Includes !=null){
                 query= spec.Includes.Aggregate(query, (current,include) => current.Include(include) );
            }
               
            return query;
        }
    }
}