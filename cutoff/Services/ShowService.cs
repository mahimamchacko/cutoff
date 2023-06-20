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

    public List<Show> BuildShowGrid(string userName)
    {
        List<Show> output = new List<Show>();

        var shows = _dataAccessor.GetShows();
        var networks = _dataAccessor.GetNetworks();
        var showNetworks = _dataAccessor.GetShowNetworks();
        var userShows = _dataAccessor.GetUserShows().Where(u => u.UserName == userName);
        var availableShows = shows.OrderBy(s => s.ShowName);

        foreach (var show in availableShows)
        {
            var availableNetworks = showNetworks.Where(s => s.ShowId == show.ShowId).Select(n => n.NetworkId);
            var userWatch = userShows.Where(s => s.ShowId == show.ShowId).FirstOrDefault();
            output.Add(new Show
            {
                ShowId = show.ShowId,
                ShowName = show.ShowName,
                UserWatch = (userWatch != null)
                                ? true
                                : false,
                Networks = networks.Where(n => availableNetworks.Contains(n.NetworkId)).ToList()
            });
        }

        return output;
    }

    public Show BuildShowModal(string userName, int showId)
    {
        Show output = new Show();

        var shows = _dataAccessor.GetShows();
        var networks = _dataAccessor.GetNetworks();
        var showNetworks = _dataAccessor.GetShowNetworks();
        var showSeasons = _dataAccessor.GetShowSeasons();
        var showEpisodes = _dataAccessor.GetShowEpisodes();
        var userShowEpisodes = _dataAccessor.GetUserShowEpisodes().Where(u => u.UserName == userName && u.ShowId == showId);

        var show = shows.Where(s => s.ShowId == showId).First();
        var availableNetworks = showNetworks.Where(s => s.ShowId == show.ShowId).Select(n => n.NetworkId);
        var availableShowEpisodes = showEpisodes.Where(s => s.ShowId == showId).OrderBy(x => x.SeasonNumber).ThenBy(y => y.EpisodeNumber);

        output.ShowId = showId;
        output.ShowName = show.ShowName;
        output.Networks = networks.Where(n => availableNetworks.Contains(n.NetworkId)).ToList();
        output.Seasons = showSeasons.Where(s => s.ShowId == showId).OrderBy(x => x.SeasonNumber).ToList();
        output.Episodes = new List<ShowEpisode>();

        foreach(var episode in availableShowEpisodes)
        {
            var userWatch = userShowEpisodes.Where(u => u.SeasonNumber == episode.SeasonNumber && u.EpisodeNumber == episode.EpisodeNumber).FirstOrDefault();
            output.Episodes.Add(new ShowEpisode
            {
                ShowId = episode.ShowId,
                SeasonNumber = episode.SeasonNumber,
                EpisodeNumber = episode.EpisodeNumber,
                UserWatch = (userWatch != null)
                                ? true
                                : false,
                EpisodeName = episode.EpisodeName,
                EpisodeDate = episode.EpisodeDate
            });
        }

        return output;
    }

    public void ToggleShow(string userName, int showId)
    {
        UserShowDTO userShow = new UserShowDTO
        {
            UserName = userName,
            ShowId = showId,
        };

        _dataAccessor.ToggleShow(userShow);
    }

    public void ToggleShowEpisode(string userName, int showId, int seasonNumber, int episodeNumber)
    {
        UserShowEpisodeDTO userShowEpisode = new UserShowEpisodeDTO
        {
            UserName = userName,
            ShowId = showId,
            SeasonNumber = seasonNumber,
            EpisodeNumber = episodeNumber,
        };

        _dataAccessor.ToggleShowEpisode(userShowEpisode);
    }
}

