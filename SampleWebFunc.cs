using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SiliconValve.Demo.Redaction;
using SiliconValve.Demo.Models;

namespace SiliconValve.Demo;

public class SampleWebFunc(ILoggerFactory loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<SampleWebFunc>();

    [Function("SampleWebFunc")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        //
        // Create a sample Person Record - in a real-world scenario this could be passed in as a parameter to the HTTP function
        //
        var personRecord = new PersonRecordRequest("John", "Doe", "johndoe@example.biz", "555-555-5555", "123 Main St", "Sydney", new DateOnly(1980, 1, 1));

        //
        // Log the record using our custom extension method
        //
        _logger.LogPersonProcessed(personRecord);

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        response.WriteString("Welcome to Azure Functions!");

        return response;
    }
}