using System;
using System.Collections.Generic;

namespace NorthwindMvcDemo.Models;

public partial class Categories
{
    public int CategoryID { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<Products> Products { get; set; } = new List<Products>();
}
