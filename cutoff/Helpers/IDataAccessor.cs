using System;
using cutoff.Models;

namespace cutoff.Helpers;

public interface IDataAccessor
{
    public List<EpisodeDTO> GetEpisodes();

    public List<GenreDTO> GetGenres();

    public List<NetworkDTO> GetNetworks();

    public List<SeasonDTO> GetSeasons();

    public List<ShowDTO> GetShows();

    public List<ShowEpisodeDTO> GetShowEpisodes();

    public List<ShowGenreDTO> GetShowGenres();

    public List<ShowNetworkDTO> GetShowNetworks();

    public List<ShowSeasonDTO> GetShowSeasons();
}

