using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    { 
        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria=criteria;
        }
        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;} = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy {get; private set;}

        public Expression<Func<T, object>> OrderByDesc  {get; private set;}

        public int Take {get; private set;}
        public int Skip {get; private set;}
        public bool IsPaginfEnable {get; private set;}
        public void AddIncludes(Expression<Func<T, object>> includeExpress){
            Includes.Add(includeExpress);
        }

        public void AddOrderby(Expression<Func<T, object>> orderByExpress){
            OrderBy=orderByExpress;
        }
         public void AddOrderbyDesc(Expression<Func<T, object>> orderByDescExpress){
             OrderByDesc=orderByDescExpress;
        }

        protected void AddPaging(int skip, int take){
            Skip=skip;
            Take=take;
            IsPaginfEnable=true;
        }
    }
}