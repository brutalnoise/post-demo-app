using Newtonsoft.Json;
using PostDemoApp.Entities.Base;
using PostDemoApp.Extensions;
using PostDemoApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PostDemoApp.Repositories
{
    public abstract class BaseRepository<TEntity>: IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly string completeFilePath;
        public BaseRepository()
        {
            this.completeFilePath = FilePathExtensions.AbsolutePathToJsonFile(typeof(TEntity));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            
            IEnumerable<TEntity> data = null;

            if(File.Exists(this.completeFilePath))
            {
                data = await GetAllFromDisk(this.completeFilePath);
            }
            else
            {
                await WriteToFileAsync(this.completeFilePath, data);
            }

            return data;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {

            IEnumerable<TEntity> data = null;

            if (File.Exists(this.completeFilePath))
            {
                data = await GetAllFromDisk(this.completeFilePath);
            }

            return data.FirstOrDefault(d => d.Id == id);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var allEntities = await this.GetAllAsync();
            var allEntitiesList = allEntities.ToList();
            var matching = allEntitiesList.FirstOrDefault(e => e.Id == entity.Id);

            if(matching != null)
            {
                allEntitiesList[allEntitiesList.IndexOf(matching)] = entity;
            }

            await WriteToFileAsync(this.completeFilePath, allEntitiesList);
        }

        public virtual async Task<int> AddAsync(TEntity entity)
        {
            var allEntities = await this.GetAllAsync();

            var allEntitiesList = allEntities.OrderBy(x => x.Id).ToList();

            entity.Id = allEntitiesList.Count > 0 ? allEntitiesList.LastOrDefault().Id + 1 : 1;

            allEntitiesList.Add(entity);

            await WriteToFileAsync(this.completeFilePath, allEntitiesList);

            return entity.Id;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var allEntities = await this.GetAllAsync();

            allEntities = allEntities.Where(e => e.Id != id);

            await WriteToFileAsync(this.completeFilePath, allEntities);
        }

        #region helpers 

        private async Task WriteToFileAsync(string completeFilePath, IEnumerable<TEntity> data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            await File.WriteAllTextAsync(completeFilePath, json);
        }

        private async Task<IEnumerable<TEntity>> GetAllFromDisk(string completeFilePath)
        {
            string jsonString = await File.ReadAllTextAsync(completeFilePath);
            var data = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(jsonString);
            return data;
        }

        #endregion
    }
}
