using System;

namespace cutoff.Models;

public class Show
{
    public long ShowId { get; set; }

    public string ShowName { get; set; } = null!;

    public bool UserWatch { get; set; }

    public List<Network>? Networks { get; set; }

    public List<Genre>? Genres { get; set; }

    public List<ShowSeasonDTO>? Seasons { get; set; }

    public List<ShowEpisode>? Episodes { get; set; }
}