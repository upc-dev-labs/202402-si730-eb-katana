namespace eb4364u20201e843.API.Scm.Domain.Model.ValueObjects;

/// <summary>
///     Represents the business identifier PartNumber as a value object with a UUID.
/// </summary>
/// <remarks>
///     Katana requires partNumber to be a unique business identifier,
///     internally stored as a UUID and mapped as an owned type.
/// </remarks>
/// <author>Author</author>
public record PartNumber(Guid Identifier)
{
    /// <summary>
    ///     Parameterless constructor that generates a new UUID.
    ///     Useful when creating new Parts.
    /// </summary>
    public PartNumber() : this(Guid.NewGuid()) { }
}