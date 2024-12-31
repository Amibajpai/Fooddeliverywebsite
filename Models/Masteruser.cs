using System;
using System.Collections.Generic;

namespace Fooddeliverywebsite.Models;

public partial class Masteruser
{
    public int Userid { get; set; }

    public string? Username { get; set; }

    public string? Usertype { get; set; }

    public string? DefaultAddress { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
