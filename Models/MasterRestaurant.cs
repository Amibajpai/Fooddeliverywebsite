using System;
using System.Collections.Generic;

namespace Fooddeliverywebsite.Models;

public partial class MasterRestaurant
{
    public int Restaurantid { get; set; }

    public string? Restaurantname { get; set; }

    public TimeOnly? Openingtime { get; set; }

    public TimeOnly? Closingtime { get; set; }

    public int? Operatingtime { get; set; }

    public string? Address { get; set; }

    public string? Description { get; set; }

    public int? Phone { get; set; }

    public string? Emailaddress { get; set; }
}
