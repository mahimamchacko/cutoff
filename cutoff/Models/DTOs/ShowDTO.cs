﻿using System;
using System.Collections.Generic;

namespace cutoff.Models;

public partial class ShowDTO
{
    public long ShowId { get; set; }

    public string ShowName { get; set; } = null!;

    public long LanguageId { get; set; }
}
