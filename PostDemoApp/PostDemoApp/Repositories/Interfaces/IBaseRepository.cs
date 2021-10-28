using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostDemoApp.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
