using System;
using cutoff.Helpers;
using cutoff.Services;

namespace cutoff.Models;

public class ShowMovalVM
{
    public Show Show { get; set; }

    public ShowMovalVM(DataAccessor dataAccessor, ShowService showService, int showId)
    {
        var shows = dataAccessor.GetShows();
        var networks = dataAccessor.GetNetworks();
        var showNetworks = dataAccessor.GetShowNetworks();
        var showSeasons = dataAccessor.GetShowSeasons();
        var showEpisodes = dataAccessor.GetShowEpisodes();

        Show = showService.BuildShowModal(shows, networks, showNetworks, showSeasons, showEpisodes, showId);
    }
}