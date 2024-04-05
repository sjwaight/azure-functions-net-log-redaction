using Microsoft.Extensions.Logging;
using SiliconValve.Demo.Models;

namespace SiliconValve.Demo.Redaction;

public static partial class Log
{
    /// <summary>
    /// Extension method that logs a person record being processed.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    /// <param name="person">Person record to log.</param>
    [LoggerMessage(LogLevel.Information, "Person record processed.")]
    public static partial void LogPersonProcessed(this ILogger logger, [LogProperties] PersonRecordRequest person);
}