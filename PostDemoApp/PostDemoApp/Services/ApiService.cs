using Newtonsoft.Json;
using PostDemoApp.Constants;
using PostDemoApp.Entities;
using PostDemoApp.Extensions;
using PostDemoApp.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PostDemoApp.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient httpClient;

        public ApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Comment>> GetComments()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Comment>>($"{ApiEndpoints.ApiBaseUrl}{ApiEndpoints.CommentsEndpoint}");
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Post>>($"{ApiEndpoints.ApiBaseUrl}{ApiEndpoints.PostsEndpoint}");
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<User>>($"{ApiEndpoints.ApiBaseUrl}{ApiEndpoints.UsersEndpoint}");
        }

        public async Task MigrateData()
        {
            var posts = await this.GetPosts();
            var pathToPostsApiFile = FilePathExtensions.AbsolutePathToJsonFile(typeof(Post));
            await this.WriteToFileAsync(pathToPostsApiFile, posts);

            var comments = await this.GetComments();
            var pathToCommentsApiFile = FilePathExtensions.AbsolutePathToJsonFile(typeof(Comment));
            await this.WriteToFileAsync(pathToCommentsApiFile, comments);

            var users = await this.GetUsers();
            var user = new User();
            var pathToUsersApiFile = FilePathExtensions.AbsolutePathToJsonFile(typeof(User));
            await this.WriteToFileAsync(pathToUsersApiFile, users);

        }

        #region helpers 

        private async Task WriteToFileAsync<TEntity>(string completeFilePath, IEnumerable<TEntity> data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            await File.WriteAllTextAsync(completeFilePath, json);
        }

        #endregion
    }
}
