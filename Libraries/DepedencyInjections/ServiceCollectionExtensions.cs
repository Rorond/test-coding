using System;
using test_coding.Services;
namespace test_coding.Libraries.DepedencyInjections
{
	public static class ServiceCollectionExtensions
	{
        public static void AddService(this IServiceCollection services)
        {
            services
                .AddTransient<ReverceService>()
                .AddTransient<BinaryTreeService>();
        }
    }
}

