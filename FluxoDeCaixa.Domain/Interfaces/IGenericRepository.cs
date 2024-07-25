using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Domain.Interfaces
{
    internal interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
