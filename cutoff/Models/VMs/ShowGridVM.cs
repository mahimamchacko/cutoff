using System;
using cutoff.Helpers;
using cutoff.Services;

namespace cutoff.Models;

public class ShowGridVM
{
    public List<Show> Shows { get; set; }

	public ShowGridVM(DataAccessor dataAccessor, ShowService showService)
	{
		var shows = dataAccessor.GetShows();
		var networks = dataAccessor.GetNetworks();
		var showNetworks = dataAccessor.GetShowNetworks();

		Shows = showService.BuildShowGrid(shows, networks, showNetworks);
	}
}

