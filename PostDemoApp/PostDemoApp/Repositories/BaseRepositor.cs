using PostDemoApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PostDemoApp.Repositories
{
    public abstract class BaseRepository<TEntity>: IBaseRepository<TEntity>
    {
        private readonly HttpClient httpClient;
        protected string baseUrl = "";
        public BaseRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<TEntity>>(baseUrl);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
