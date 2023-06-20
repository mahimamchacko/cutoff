using System;
using System.Collections.Generic;

namespace cutoff.Models;

public partial class ShowEpisode
{
    public long ShowId { get; set; }

    public long SeasonNumber { get; set; }

    public long EpisodeNumber { get; set; }

    public bool UserWatch { get; set; }

    public string? EpisodeName { get; set; }

    public DateTime EpisodeDate { get; set; }
}
