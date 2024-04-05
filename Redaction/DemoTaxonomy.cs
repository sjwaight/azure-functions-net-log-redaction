using Microsoft.Extensions.Compliance.Classification;

namespace SiliconValve.Demo.Redaction;

/// <summary>
/// Simple data classifications for testing.
/// </summary>
public static class DemoTaxonomy
{
    /// <summary>
    /// Gets the name of this classification taxonomy.
    /// </summary>
    public static string TaxonomyName => typeof(DemoTaxonomy).FullName!;

    /// <summary>
    /// Sensitive data classification.
    /// </summary>
    public static DataClassification SensitiveData => new(TaxonomyName, nameof(SensitiveData));
}