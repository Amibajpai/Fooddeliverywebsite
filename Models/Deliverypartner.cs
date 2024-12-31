using System;
using System.Collections.Generic;

namespace Fooddeliverywebsite.Models;

public partial class Deliverypartner
{
    public int Deliverypartnerid { get; set; }

    public string? Deliverypartnername { get; set; }

    public int OrderId { get; set; }

    public int Restaurantid { get; set; }

    public string? Itemdelivered { get; set; }

    public TimeOnly? Orderpickuptime { get; set; }

    public TimeOnly? Droptime { get; set; }

    public TimeOnly? Totaldeliverytime { get; set; }

    public bool? Orderstatus { get; set; }

    public string? Remark { get; set; }

    public decimal? Revenueofday { get; set; }

    public string? Typeofrevenue { get; set; }
}
