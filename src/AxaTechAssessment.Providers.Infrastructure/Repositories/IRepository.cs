using AxaTechAssessment.Providers.Application.Common.Results;
using System.Linq.Expressions;

namespace AxaTechAssessment.Providers.Infrastructure.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    ResultDto<string?> Get(
        Expression<Func<TEntity, bool>> filter = null!,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
        string includeProperties = "");

    ResultDto<string?> GetById(object id);

    ResultDto Insert(TEntity entity);

    ResultDto Delete(object id);

    ResultDto Update(TEntity entityToUpdate);
}
