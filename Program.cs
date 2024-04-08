using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Compliance.Classification;
using SiliconValve.Demo.Redaction;
using Microsoft.Extensions.Configuration;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureLogging((hostContext, logging) =>
        {
            logging.AddJsonConsole();
            // Enable redaction logging if configured
            if(hostContext.Configuration.GetValue<bool>("EnableRedaction", true))
            {
                logging.EnableRedaction();
            }
        })
    .ConfigureServices((hostContext, services) =>
        {
            // Add Application Insights as default logger
            services.AddApplicationInsightsTelemetryWorkerService();
            services.ConfigureFunctionsApplicationInsights();

            // Enable redaction logging if configured
            if(hostContext.Configuration.GetValue<bool>("EnableRedaction", true))
            {
                services.AddRedaction(redactionBuilder =>
                    {
                        // Assigns a redactor to use for a set of data classifications.
                        redactionBuilder.SetRedactor<ExplicitRedactor>(new DataClassificationSet(DemoTaxonomy.SensitiveData));  
                        // The `ErasingRedactor` is the default fallback redactor. If no redactor is configured for a data classification then the data will be erased.
                        //redactionBuilder.SetFallbackRedactor<MyFallbackRedactor>();
                    });
            }
        })
    .Build();

host.Run();