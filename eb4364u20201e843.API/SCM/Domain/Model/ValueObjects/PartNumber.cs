namespace eb4364u20201e843.API.SCM.Domain.Model.ValueObjects;

/// <summary>
///     Represents the business identifier PartNumber as a value object with a UUID.
/// </summary>
/// <remarks>
///     Katana requires partNumber to be a unique business identifier,
///     internally stored as a UUID and mapped as an owned type.
/// </remarks>
/// <author>Author</author>
public record PartNumber
{
    public int Id { get; private set; }

    public Guid Identifier { get; private set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PartNumber"/> record with a specified identifier.
    /// </summary>
    public PartNumber() : this(Guid.NewGuid()) { }

    public PartNumber(Guid identifier)
    {
        Identifier = identifier;
    }
}