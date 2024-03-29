﻿using Domain.Entities.Abstractions;

namespace Infrastructure.Specifications.Abstractions;
public static class SpecificationEvaluator<TEntity>
    where TEntity : IEntity
{
    public static IQueryable<TEntity> GetQuery(
        IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> specification)
    {
        var query = inputQuery;

        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }

        if (specification.OrderByExpression != null)
        {
            query = query.OrderBy(specification.OrderByExpression);
        }
        else if (specification.OrderByDescendingExpression != null)
        {
            query = query.OrderByDescending(specification.OrderByDescendingExpression);
        }

        if (specification.IsPagingEnabled)
        {
            query = query.Skip(specification.Skip)
                         .Take(specification.Take);
        }
        return query;
    }
}
