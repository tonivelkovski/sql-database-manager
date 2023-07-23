using System.Threading.Tasks;
using Testcontainers.MsSql;
using Xunit;

namespace SQL_Database_Generator.IntegrationTests
{
    public class IntegrationTest : IAsyncLifetime
    {
        private MsSqlContainer _dockerContainer;

        public async Task InitializeAsync()
        {
            _dockerContainer = new MsSqlBuilder()
                .WithPortBinding(1433, MsSqlBuilder.MsSqlPort)
                .Build();

            await _dockerContainer.StartAsync();

            TestDbConnector.Destory();
        }

        public async Task DisposeAsync()
        {
            if (_dockerContainer != null)
            {
                await _dockerContainer.StopAsync();
            }
        }
    }
}
