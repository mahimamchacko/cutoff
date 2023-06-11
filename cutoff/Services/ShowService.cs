using System;
using cutoff.Helpers;
using cutoff.Models;

namespace cutoff.Services;

public class ShowService
{
    private readonly DataAccessor _dataAccessor;

    public ShowService(DataAccessor dataAccessor)
	{
        _dataAccessor = dataAccessor;
    }

    public List<Show> BuildShowGrid(List<ShowDTO> shows, List<NetworkDTO> networks, List<ShowNetworkDTO> showNetworks)
    {
        List<Show> output = new List<Show>();
        var availableShows = shows.OrderBy(s => s.ShowName);
        foreach (var show in availableShows)
        {
            var availableNetworks = showNetworks.Where(s => s.ShowId == show.ShowId).Select(n => n.NetworkId);
            output.Add(new Show
            {
                ShowId = show.ShowId,
                ShowName = show.ShowName,
                Networks = networks.Where(n => availableNetworks.Contains(n.NetworkId)).ToList()
            });
        }
        return output;
    }

    public Show BuildShowModal(List<ShowDTO> shows, List<NetworkDTO> networks, List<ShowNetworkDTO> showNetworks,
        List<ShowSeasonDTO> showSeasons, List<ShowEpisodeDTO> showEpisodes, int showId)
    {
        Show output = new Show();
        var show = shows.Where(s => s.ShowId == showId).First();
        var availableNetworks = showNetworks.Where(s => s.ShowId == show.ShowId).Select(n => n.NetworkId);

        output.ShowId = showId;
        output.ShowName = show.ShowName;
        output.Networks = networks.Where(n => availableNetworks.Contains(n.NetworkId)).ToList();
        output.Seasons = showSeasons.Where(s => s.ShowId == showId).OrderBy(x => x.SeasonNumber).ToList();
        output.Episodes = showEpisodes.Where(s => s.ShowId == showId).OrderBy(x => x.SeasonNumber).ThenBy(y => y.EpisodeNumber).ToList();

        return output;
    }
}

