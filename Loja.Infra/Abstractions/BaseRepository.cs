using System.Linq.Expressions;
using Loja.Domain.Contracts;
using Loja.Domain.Entities;
using Loja.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Abstractions;

public abstract class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : BaseEntity
{ 
    private readonly DbSet<TEntity> _dbSet;
    protected readonly LojaDbContext Context;

    protected BaseRepository(LojaDbContext context)
    {
        Context = context;
        _dbSet = context.Set<TEntity>();
    }


    public async Task<bool> Create(TEntity type)
    {
        _dbSet.Add(type);
        return await Context.SaveChangesAsync() > 0;

    }

    public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
    {
        var queryable = _dbSet.AsQueryable();
        queryable = queryable.Where(predicate);

        return await queryable.ToListAsync();
    }

    public async Task<TEntity?> Get(int id)
    {
        var queryable = _dbSet.AsQueryable();
        queryable = queryable.Where(x=>x!.Id == id);
        return await queryable.FirstOrDefaultAsync();
    }

    public async Task<bool> Update(TEntity type)
    {
        Context.Entry(type).State = EntityState.Modified;
        return await Context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;

        _dbSet.Remove(entity);
        return await Context.SaveChangesAsync() > 0;

    }


    private void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if (disposing)
        {
            Context.Dispose();
        }
    }
    
    ~BaseRepository()
    {
        Dispose(false);
    }

    private void ReleaseUnmanagedResources()
    {
        
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}