using System;
using System.Collections.Generic;

namespace NorthwindMvcDemo.Models;

public partial class Order_Subtotals
{
    public int OrderID { get; set; }

    public decimal? Subtotal { get; set; }
}
