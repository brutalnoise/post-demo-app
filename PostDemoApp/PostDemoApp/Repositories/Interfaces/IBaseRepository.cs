using PostDemoApp.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostDemoApp.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity: BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task<int> AddAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
