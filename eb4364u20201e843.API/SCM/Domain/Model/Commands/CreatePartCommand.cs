namespace eb4364u20201e843.API.SCM.Domain.Model.Commands;

public record CreatePartCommand(
    string Name,
    string PartType,
    int MaxProductionCapacity
);