using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostDemoApp.Services.Interfaces
{
    public interface IBaseServiceInterface<TModel>
    {
        Task<TModel> Add(TModel model);
        Task<TModel> Update(TModel model);
        Task Delete(int id);
        Task<IEnumerable<TModel>> List();
        Task<TModel> GetById(int id);
    }
}
