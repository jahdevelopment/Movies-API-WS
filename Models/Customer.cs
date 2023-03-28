using System;
using System.Collections.Generic;

namespace Movies_API_WS.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int Age { get; set; }

    public string Gender { get; set; } = null!;

    public string Occupation { get; set; } = null!;

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();
}
