using Microsoft.Extensions.DependencyInjection;

namespace Booklist.test
{
    public class TestBase
    {
        protected IServiceProvider CreateProvider()
        {
            return this.AddServices(new ServiceCollection()).BuildServiceProvider();
        }

        protected virtual IServiceCollection AddServices(ServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}