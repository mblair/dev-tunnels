using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.DevTunnels.Contracts.Validation;

namespace Microsoft.DevTunnels.Contracts;

using static TunnelConstraints;

/// <summary>
/// Tunnel type used for tunnel service API versions greater than 2023-05-23-preview
/// </summary>
public class Tunnel : TunnelBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tunnel"/> class.
    /// </summary>
    public Tunnel()
    {
    }

    /// <summary>
    /// Gets or sets the ID of the tunnel, unique within the cluster.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RegularExpression(TunnelV2IdPattern)]
    [StringLength(TunnelV2IdMaxLength, MinimumLength = TunnelV2IdMinLength)]
    public override string? TunnelId { get; set; }

    /// <summary>
    /// Gets or sets the tags of the tunnel.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [MaxLength(MaxTags)]
    [ArrayStringLength(TagMaxLength, MinimumLength = TagMinLength)]
    [ArrayRegularExpression(TagPattern)]
    public string[]? Labels { get; set; }
}
