using System;
using System.Collections.Generic;

namespace NorthwindMvcDemo.Models;

public partial class CustomerDemographics
{
    public string CustomerTypeID { get; set; } = null!;

    public string? CustomerDesc { get; set; }

    public virtual ICollection<Customers> Customer { get; set; } = new List<Customers>();
}
