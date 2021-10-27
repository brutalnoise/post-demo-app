using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostDemoApp.Services.Interfaces
{
    public interface IBaseServiceInterface<TModel>
    {
        public Task<TModel> Add(TModel model);
        public Task<TModel> Update(TModel model);
        public Task Delete(int id);
        public Task<IEnumerable<TModel>> List();
    }
}
