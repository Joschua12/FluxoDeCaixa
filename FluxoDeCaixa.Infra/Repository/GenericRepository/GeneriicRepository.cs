using FluxoDeCaixa.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FluxoDeCaixa.Infra.Repository.GenericRepository
{
    internal class GeneriicRepository<TEntity>
       : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MainContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public GenericRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Update(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _dbContext.Remove(_dbSet.Find(id));

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToArrayAsync();
        }

        protected async Task<IQueryable<TEntity>> Query() => _dbSet.AsNoTracking();
    }
}
