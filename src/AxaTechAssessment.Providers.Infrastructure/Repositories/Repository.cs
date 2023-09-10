using AxaTechAssessment.Providers.Application.Common.Results;
using AxaTechAssessment.Providers.Application.Common.Results.Builders;
using AxaTechAssessment.Providers.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.Json;

namespace AxaTechAssessment.Providers.Infrastructure.Repositories;

public class Repository<TEntity> 
    where TEntity : class, 
    IRepository<TEntity>
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    private readonly IResultDtoBuilder _resultDtoBuilder;
    private readonly IResultDtoBuilder<string?> _genericResultDtoBuilder;

    public Repository(ApplicationDbContext context, IResultDtoBuilder resultDtoBuilder, IResultDtoBuilder<string?> genericResultDtoBuilder)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
        _resultDtoBuilder = resultDtoBuilder;
        _genericResultDtoBuilder = genericResultDtoBuilder;
    }

    public ResultDto Delete(object id)
    {
        TEntity entityToDelete = _dbSet.Find(id)!;

        if (_context.Entry(entityToDelete).State == EntityState.Detached)
            _dbSet.Attach(entityToDelete);

        _dbSet.Remove(entityToDelete);

        return _resultDtoBuilder.BuildSuccess();
    }

    public ResultDto<string?> Get(
        Expression<Func<TEntity, bool>> filter = null!, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, 
        string includeProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter).AsNoTracking();
        }

        foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        var entities = orderBy != null ? orderBy(query).ToList() : query.ToList();
        return _genericResultDtoBuilder.BuildSuccess(JsonSerializer.Serialize(entities));
    }

    public ResultDto<string?> GetById(object id)
    {
        var entity = JsonSerializer.Serialize(_dbSet.Find(id));
        return _genericResultDtoBuilder.BuildSuccess(entity);
    }

    public ResultDto Insert(TEntity entity)
    {
        _dbSet.Add(entity);
        return _resultDtoBuilder.BuildSuccess();
    }

    public ResultDto Update(TEntity entityToUpdate)
    {
        _dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
        return _resultDtoBuilder.BuildSuccess();
    }
}
