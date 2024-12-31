using System;
using System.Collections.Generic;

namespace Fooddeliverywebsite.Models;

public partial class Mastercuisine
{
    public int Cuisineid { get; set; }

    public string? Cuisinename { get; set; }

    public int Restaurantid { get; set; }

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
