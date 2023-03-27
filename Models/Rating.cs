using System;
using System.Collections.Generic;

namespace Movies_API_WS.Models;

public partial class Rating
{
    public int CustomerId { get; set; }

    public int MovieId { get; set; }

    public int Rating1 { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
