using eb4364u20201e843.API.SCM.Domain.Model.Aggregates;
using eb4364u20201e843.API.SCM.Domain.Model.Commands;

namespace eb4364u20201e843.API.SCM.Domain.Services;

/// <summary>
///     Service interface for handling commands related to Part aggregate roots.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public interface IPartCommandService
{
    /// <summary>
    ///     Handles the creation of a new Part aggregate using the provided command.
    /// </summary>
    /// <param name="command">The command containing the Part data.</param>
    /// <returns>The created Part aggregate, or null if creation fails.</returns>
    Task<Part?> Handle(CreatePartCommand command);
}