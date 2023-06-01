using System;
using cutoff.Models;

namespace cutoff.Helpers;

public interface IDataAccessor
{
    public List<Episode> GetEpisodes();

    public List<Genre> GetGenres();

    public List<Network> GetNetworks();

    public List<Season> GetSeasons();

    public List<Show> GetShows();

    public List<ShowEpisode> GetShowEpisodes();

    public List<ShowGenre> GetShowGenres();

    public List<ShowNetwork> GetShowNetworks();

    public List<ShowSeason> GetShowSeasons();
}

