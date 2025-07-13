namespace eb4364u20201e843.API.Scm.Domain.Model.Commands;

public record CreatePartCommand(
    string Name,
    string PartType,
    int MaxProductionQuantity
);