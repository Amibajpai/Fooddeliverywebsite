using System;
using System.Collections.Generic;

namespace Fooddeliverywebsite.Models;

public partial class Restaurant
{
    public int Userid { get; set; }

    public string? Ordereditem { get; set; }

    public int? Itemprice { get; set; }

    public decimal? Itemrating { get; set; }

    public int? Totalrevenue { get; set; }

    public string? Revenuetype { get; set; }

    public string? Activeoffers { get; set; }

    public string? Itemsinstock { get; set; }

    public string? Bestselleritems { get; set; }

    public virtual Masteruser User { get; set; } = null!;
}
