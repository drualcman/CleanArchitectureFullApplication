using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Specifications
{
    public abstract class Specification<T>
    {
        public virtual Expression<Func<T, bool>> ConditionExpression { get; }
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> expressionDelegate = ConditionExpression.Compile();
            return expressionDelegate(entity);
        }
    }
}
