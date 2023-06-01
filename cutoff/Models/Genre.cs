using System;
using System.Collections.Generic;

namespace cutoff.Models;

public partial class Genre
{
    public long GenreId { get; set; }

    public string GenreName { get; set; } = null!;
}
