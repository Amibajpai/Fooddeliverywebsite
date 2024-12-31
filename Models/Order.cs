using System;
using System.Collections.Generic;

namespace Fooddeliverywebsite.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int Userid { get; set; }

    public int Restaurantid { get; set; }

    public int? Itemqty { get; set; }

    public string? Deliverypartnername { get; set; }

    public bool? Deliverystatus { get; set; }

    public virtual Masteruser User { get; set; } = null!;
}
