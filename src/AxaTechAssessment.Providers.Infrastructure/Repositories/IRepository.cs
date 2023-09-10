using System.Linq.Expressions;

namespace AxaTechAssessment.Providers.Infrastructure.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null!,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
        string includeProperties = "");

    TEntity GetById(object id);

    void Insert(TEntity entity);

    void Delete(object id);

    void Update(TEntity entityToUpdate);
}
