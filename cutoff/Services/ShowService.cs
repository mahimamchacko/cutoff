using System;
using cutoff.Helpers;
using cutoff.Models;

namespace cutoff.Services;

public class ShowService
{
    private readonly DataAccessor _dataAccessor;
    private readonly NetworkService _networkService;
    private readonly GenreService _genreService;
    private readonly LanguageService _languageService;

    public ShowService(DataAccessor dataAccessor, NetworkService networkService, GenreService genreService, LanguageService languageService)
	{
        _dataAccessor = dataAccessor;
        _networkService = networkService;
        _genreService = genreService;
        _languageService = languageService;
    }

    public List<Show> BuildShowGrid(string userName, int networkId, int genreId, int languageId)
    {
        List<Show> output = new List<Show>();

        var shows = _dataAccessor.GetShows().Where(s => (languageId == 0 || s.LanguageId == languageId)).OrderBy(x => x.ShowName);
        var networks = _dataAccessor.GetNetworks().OrderBy(n => n.NetworkName);
        var showNetworks = _dataAccessor.GetShowNetworks();
        var genres = _dataAccessor.GetGenres();
        var showGenres = _dataAccessor.GetShowGenres();
        var userShows = _dataAccessor.GetUserShows().Where(u => u.UserName == userName);

        foreach (var show in shows)
        {
            var userWatch = userShows.Where(s => s.ShowId == show.ShowId).FirstOrDefault();

            var availableNetworks = showNetworks.Where(s => s.ShowId == show.ShowId).Select(n => n.NetworkId);
            var specificNetworks = networks.Where(n => availableNetworks.Contains(n.NetworkId)).ToList();

            var availableGenres = showGenres.Where(s => s.ShowId == show.ShowId).Select(g => g.GenreId);
            var specificGenres = genres.Where(g => availableGenres.Contains(g.GenreId)).ToList();

            output.Add(new Show
            {
                ShowId = show.ShowId,
                ShowName = show.ShowName,
                UserWatch = (userWatch != null)
                                ? true
                                : false,
                Networks = _networkService.ConvertToNetwork(specificNetworks),
                Genres = _genreService.ConvertToGenre(specificGenres)
            });
        }

        output = output.Where(s => (networkId == 0 || s.Networks?.Where(n => n.NetworkId == networkId).Count() > 0)
                                   && (genreId == 0 || s.Genres?.Where(g => g.GenreId == genreId).Count() > 0)).ToList();
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
        var specificNetworks = networks.Where(n => availableNetworks.Contains(n.NetworkId)).ToList();
        var availableShowEpisodes = showEpisodes.Where(s => s.ShowId == showId).OrderBy(x => x.SeasonNumber).ThenBy(y => y.EpisodeNumber);

        output.ShowId = showId;
        output.ShowName = show.ShowName;
        output.Networks = _networkService.ConvertToNetwork(specificNetworks);
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

