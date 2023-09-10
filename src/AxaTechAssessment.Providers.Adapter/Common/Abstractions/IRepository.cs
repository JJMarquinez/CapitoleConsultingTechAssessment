using AxaTechAssessment.Providers.Application.Common.Results;
using System.Linq.Expressions;

namespace AxaTechAssessment.Providers.Adapter.Common.Abstractions;

public interface IRepository<TEntity> where TEntity : class
{
    ResultDto<string?> Get(
        Expression<Func<TEntity, bool>> filter = null!,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
        string includeProperties = "");

    Task<ResultDto<string?>> GetByIdAsync(object id);

    Task<ResultDto> InsertAsync(TEntity entity);

    ResultDto Delete(object id);

    ResultDto Update(TEntity entityToUpdate);
}
