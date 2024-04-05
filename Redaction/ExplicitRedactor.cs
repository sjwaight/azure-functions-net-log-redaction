using Microsoft.Extensions.Compliance.Redaction;

namespace SiliconValve.Demo.Redaction;

/// <summary>
/// Explicitly redacts data by replacing it with a fixed string value of '**REDACTED**'.
/// </summary>
public class ExplicitRedactor : Redactor
{
    private const string ErasedValue = "**REDACTED**";

    public override int GetRedactedLength(ReadOnlySpan<char> input)
        => ErasedValue.Length;

    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        ErasedValue.CopyTo(destination);
        return ErasedValue.Length;
    }
}