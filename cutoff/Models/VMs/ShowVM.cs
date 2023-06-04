using System;
using cutoff.Helpers;
using cutoff.Services;

namespace cutoff.Models;

public class ShowVM
{
    public List<Show> Shows { get; set; }

	public ShowVM(DataAccessor dataAccessor, ShowService showService)
	{
		var shows = dataAccessor.GetShows();
		var networks = dataAccessor.GetNetworks();
		var showNetworks = dataAccessor.GetShowNetworks();

		Shows = showService.BuildShows(shows, networks, showNetworks);
	}
}

