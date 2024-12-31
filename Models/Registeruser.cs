using System;
using System.Collections.Generic;

namespace Fooddeliverywebsite.Models;

public partial class Registeruser
{
    public string? Username { get; set; }

    public string? Address { get; set; }

    public string PhoneNo { get; set; } = null!;
}
