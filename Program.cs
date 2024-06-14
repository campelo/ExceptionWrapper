using ExceptionWrapper;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<CustomExceptionInterceptor>();
        services.AddTransient<IMyService1>(provider =>
        {
            var interceptor = provider.GetRequiredService<CustomExceptionInterceptor>();
            return ProxyGeneratorFactory.CreateProxy<MyService1>(interceptor);
        });
    })
    .Build();

host.Run();
