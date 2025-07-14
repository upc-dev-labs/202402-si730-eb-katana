namespace eb4364u20201e843.API.MRP.Domain.Model.ValueObjects;

/// <summary>
///     Represents the ItemPartNumber as a value object with a UUID.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public record ItemPartNumber
{
    /// <summary>
    ///     Gets the internal database key used for EF Core mapping.
    ///     Shared with the owning BillOfMaterialsItem entity as a foreign key.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    ///     Gets the business identifier for the ItemPartNumber, stored as a UUID.
    /// </summary>
    public Guid Identifier { get; private set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemPartNumber"/> record
    ///     with a newly generated UUID identifier.
    /// </summary>
    public ItemPartNumber() : this(Guid.NewGuid()) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ItemPartNumber"/> record
    ///     with a specified UUID identifier.
    /// </summary>
    /// <param name="identifier">The UUID to use as the business identifier.</param>
    public ItemPartNumber(Guid identifier)
    {
        Identifier = identifier;
    }

    /// <summary>
    ///     Initializes an ItemPartNumber from a string representation of a UUID.
    /// </summary>
    /// <param name="identifierString">The string representation of the UUID.</param>
    public ItemPartNumber(string identifierString) : this(Guid.Parse(identifierString)) { }

    /// <summary>
    ///     Creates an ItemPartNumber from a string if valid, or returns null.
    /// </summary>
    /// <param name="identifierString">The string to parse.</param>
    /// <returns>ItemPartNumber instance or null.</returns>
    public static ItemPartNumber? FromString(string identifierString)
    {
        return Guid.TryParse(identifierString, out var guid)
            ? new ItemPartNumber(guid)
            : null;
    }
}