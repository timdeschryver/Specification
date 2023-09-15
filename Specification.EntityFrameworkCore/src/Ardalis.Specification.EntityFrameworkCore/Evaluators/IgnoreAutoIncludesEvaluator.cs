using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ardalis.Specification.EntityFrameworkCore
{
  public class IgnoreAutoIncludesEvaluator : IEvaluator
  {
    private IgnoreAutoIncludesEvaluator() { }
    public static IgnoreAutoIncludesEvaluator Instance { get; } = new IgnoreAutoIncludesEvaluator();

    public bool IsCriteriaEvaluator { get; } = false;

    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> specification) where T : class
    {
      if (specification.IgnoreAutoIncludes)
      {
        query = query.IgnoreAutoIncludes();
      }

      return query;
    }
  }
}
