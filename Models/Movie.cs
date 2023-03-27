using System;
using System.Collections.Generic;

namespace Movies_API_WS.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();
}
