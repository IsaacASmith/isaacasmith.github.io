using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService("370bbc26-f659-4621-817b-3015f56f11b5");
    })
    .Build();

host.Run();