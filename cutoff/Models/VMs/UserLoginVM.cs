using System;
using System.Collections.Generic;

namespace cutoff.Models;

public class UserLoginVM
{
    public string UserName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;
}