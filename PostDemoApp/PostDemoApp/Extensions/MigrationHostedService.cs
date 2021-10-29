using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PostDemoApp.Services.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PostDemoApp.Extensions
{
    public class MigrationHostedService : IHostedService
    {
        // We need to inject the IServiceProvider so we can create 
        // the scoped service, MyDbContext
        private readonly IServiceProvider _serviceProvider;
        public MigrationHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var apiService = scope.ServiceProvider.GetRequiredService<IApiService>();

                //Do the migration asynchronously
                await apiService.MigrateData();
            }
        }

        // noop
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
