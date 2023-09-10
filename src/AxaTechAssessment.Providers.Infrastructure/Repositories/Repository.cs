using AxaTechAssessment.Providers.Adapter.Common.Abstractions;
using AxaTechAssessment.Providers.Application.Common.Errors.Builders;
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
    private readonly IErrorDtoBuilder _errorDtoBuilder;

    public Repository(
        ApplicationDbContext context, 
        IResultDtoBuilder resultDtoBuilder, 
        IResultDtoBuilder<string?> genericResultDtoBuilder, 
        IErrorDtoBuilder errorDtoBuilder)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
        _resultDtoBuilder = resultDtoBuilder;
        _genericResultDtoBuilder = genericResultDtoBuilder;
        _errorDtoBuilder = errorDtoBuilder;
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
        var errorDto = _errorDtoBuilder
            .WithCode("NotFound")
            .WithDetail("No providers found.")
            .WithHttpStatusCode(404)
            .Build();
        var resultDto = _genericResultDtoBuilder.BuildFailure(errorDto);

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
        if(entities.Any())
            resultDto = _genericResultDtoBuilder.BuildSuccess(JsonSerializer.Serialize(entities));

        return resultDto;
    }

    public async Task<ResultDto<string?>> GetByIdAsync(object id)
    {
        var errorDto = _errorDtoBuilder
            .WithCode("NotFound")
            .WithDetail(string.Format("The provider '{0}' not found.", id))
            .WithHttpStatusCode(404)
            .Build();
        var resultDto = _genericResultDtoBuilder.BuildFailure(errorDto);

        var entity = await _dbSet.FindAsync(id).ConfigureAwait(false);

        if(entity is not null)
            resultDto = _genericResultDtoBuilder.BuildSuccess(JsonSerializer.Serialize(entity));

        return resultDto;
    }

    public async Task<ResultDto> InsertAsync(TEntity entity)
    {
        var errorDto = _errorDtoBuilder
            .WithCode("InternalServerError")
            .WithDetail("An error server occured.")
            .WithHttpStatusCode(500)
            .Build();
        var resultDto = _resultDtoBuilder.BuildFailure(errorDto);

        var entityEntry = await _dbSet.AddAsync(entity).ConfigureAwait(false);

        if(entityEntry.State == EntityState.Added)
            resultDto = _resultDtoBuilder.BuildSuccess();

        return resultDto;
    }

    public ResultDto Update(TEntity entityToUpdate)
    {
        _dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
        return _resultDtoBuilder.BuildSuccess();
    }
}
