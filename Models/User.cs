using System;
using System.Collections.Generic;

namespace Fooddeliverywebsite.Models;

public partial class User
{
    public string? Location { get; set; }

    public string? Address { get; set; }

    public int? PhoneNo { get; set; }

    public string Password { get; set; } = null!;

    public string? DefaultAddress { get; set; }

    public string? Preferences { get; set; }

    public string? Username { get; set; }
}
