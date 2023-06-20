using System;
using System.Collections.Generic;

namespace cutoff.Models;

public partial class UserShowEpisodeDTO
{
    public string UserName { get; set; } = null!;

    public long ShowId { get; set; }

    public long SeasonNumber { get; set; }

    public long EpisodeNumber { get; set; }
}
