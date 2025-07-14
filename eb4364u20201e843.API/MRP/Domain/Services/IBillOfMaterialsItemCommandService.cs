using eb4364u20201e843.API.MRP.Domain.Model.Aggregates;
using eb4364u20201e843.API.MRP.Domain.Model.Commands;

namespace eb4364u20201e843.API.MRP.Domain.Services;

/// <summary>
///     Command service interface for handling the creation of BillOfMaterialsItem aggregate roots.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public interface IBillOfMaterialsItemCommandService
{
    /// <summary>
    ///     Handles the creation of a new BillOfMaterialsItem, including validation and persistence.
    /// </summary>
    /// <param name="command">The command containing the item data.</param>
    /// <returns>The created BillOfMaterialsItem aggregate.</returns>
    Task<BillOfMaterialsItem?> Handle(CreateBillOfMaterialsItemCommand command);
}