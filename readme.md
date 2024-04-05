# Azure Functions with Logging Redaction

This demonstration project shows how you can utilise [Microsoft.Extensions.Compliance.Redaction](https://learn.microsoft.com/dotnet/api/microsoft.extensions.compliance.redaction?wt.mc_id=MVP_333247&view=dotnet-plat-ext-8.0) extensions to redact sensitive information from your Azure Function logs.

There is a bit of work involved to get this working and it is currently only supported with .NET 8 and the [Azure Functions Isolated Worker model](https://learn.microsoft.com/azure/azure-functions/dotnet-isolated-process-guide?wt.mc_id=MVP_333247&tabs=linux) (which will be the only supported model from .NET 9 onwards).

Requirements to get going with the solution:

- [Visual Studio Code](https://code.visualstudio.com/download).
- [Azure Core Functions Tools](https://learn.microsoft.com/azure/azure-functions/functions-run-local?wt.mc_id=MVP_333247).
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0?wt.mc_id=MVP_333247).
- [Application Insights Instance](https://learn.microsoft.com/azure/azure-monitor/app/create-workspace-resource?wt.mc_id=MVP_333247&tabs=bicep) (optional, but you will need to remove code if you don't want to use it).

## Sample local.settings.json

To run this sample locally use a `local.settings.json` similar to the one shown below.

```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
        "APPLICATIONINSIGHTS_CONNECTION_STRING": "InstrumentationKey={YOUR_KEY};IngestionEndpoint=https://{YOUR_ENDPOINT}.applicationinsights.azure.com/;LiveEndpoint=https://{YOUR_ENDPOINT}.livediagnostics.monitor.azure.com/",
        "EnableRedaction": "false"
    }
}
```
