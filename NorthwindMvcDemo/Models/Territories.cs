﻿using System;
using System.Collections.Generic;

namespace NorthwindMvcDemo.Models;

public partial class Territories
{
    public string TerritoryID { get; set; } = null!;

    public string TerritoryDescription { get; set; } = null!;

    public int RegionID { get; set; }

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<Employees> Employee { get; set; } = new List<Employees>();
}
