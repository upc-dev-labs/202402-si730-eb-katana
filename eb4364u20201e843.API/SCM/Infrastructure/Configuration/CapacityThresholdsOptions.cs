namespace eb4364u20201e843.API.SCM.Infrastructure.Configuration;

/// <summary>
///     Configuration options for production capacity thresholds.
/// </summary>
/// <remarks>
///     Author: Author
/// </remarks>
public class CapacityThresholdsOptions
{
    /// <summary>
    ///     Gets or sets the minimum allowed production capacity.
    /// </summary>
    public int MinCapacityThreshold { get; set; }

    /// <summary>
    ///     Gets or sets the maximum allowed production capacity.
    /// </summary>
    public int MaxCapacityThreshold { get; set; }
}