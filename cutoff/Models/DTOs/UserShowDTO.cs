using System;
using System.Collections.Generic;

namespace cutoff.Models;

public partial class UserShowDTO
{
    public string UserName { get; set; } = null!;

    public int ShowId { get; set; }
}