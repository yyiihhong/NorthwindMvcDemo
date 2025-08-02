﻿using System;
using System.Collections.Generic;

namespace NorthwindMvcDemo.Models;

public partial class Products
{
    public int ProductID { get; set; }

    public string ProductName { get; set; } = null!;

    public int? SupplierID { get; set; }

    public int? CategoryID { get; set; }

    public string? QuantityPerUnit { get; set; }

    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public virtual Categories? Category { get; set; }

    public virtual ICollection<Order_Details> Order_Details { get; set; } = new List<Order_Details>();

    public virtual Suppliers? Supplier { get; set; }
}
