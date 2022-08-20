using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService("6487c28d-9060-4eb7-a5af-d3b1d126f3a6");
    })
    .Build();

host.Run();