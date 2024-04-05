using Microsoft.Extensions.Compliance.Classification;

namespace SiliconValve.Demo.Redaction;

/// <summary>
/// Sensitive data.
/// </summary>
public sealed class SensitiveDataAttribute : DataClassificationAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SensitiveDataAttribute"/> class.
    /// </summary>
    public SensitiveDataAttribute()
        : base(DemoTaxonomy.SensitiveData)
    {
    }
}