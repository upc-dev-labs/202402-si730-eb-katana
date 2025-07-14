namespace eb4364u20201e843.API.SCM.Domain.Model.ValueObjects;

/// <summary>
///     Represents the business identifier PartNumber as a value object with a UUID.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public record PartNumber
{
    /// <summary>
    ///     Gets the internal database key used for EF Core mapping.
    ///     Shared with the owning Part entity as a foreign key.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    ///     Gets the business identifier for the Part, stored as a UUID.
    /// </summary>
    public Guid Identifier { get; private set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PartNumber"/> record
    ///     with a newly generated UUID identifier.
    /// </summary>
    public PartNumber() : this(Guid.NewGuid()) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PartNumber"/> record
    ///     with a specified UUID identifier.
    /// </summary>
    /// <param name="identifier">The UUID to use as the business identifier.</param>
    public PartNumber(Guid identifier)
    {
        Identifier = identifier;
    }
}