using System;
using System.Collections.Generic;

namespace cutoff.Models;

public partial class UserDTO
{
    public string UserName { get; set; } = null!;

    public string UserFirst { get; set; } = null!;

    public string UserLast { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;
}