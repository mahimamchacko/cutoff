using System;

namespace cutoff.Models;

public class Show
{
    public long ShowId { get; set; }

    public string ShowName { get; set; } = null!;

    public List<NetworkDTO>? Networks { get; set; }

    public List<ShowSeasonDTO>? Seasons { get; set; }

    public List<ShowEpisodeDTO>? Episodes { get; set; }
}

