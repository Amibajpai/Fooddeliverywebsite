using System;
using System.Collections.Generic;

namespace Fooddeliverywebsite.Models;

public partial class Menu
{
    public int Menuid { get; set; }

    public int Restaurantid { get; set; }

    public string? Itemname { get; set; }

    public decimal? Itemprice { get; set; }

    public int Cuisineid { get; set; }

    public string? Itemcategory { get; set; }

    public virtual Mastercuisine Cuisine { get; set; } = null!;
}
