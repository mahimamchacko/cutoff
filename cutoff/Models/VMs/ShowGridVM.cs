using System;
using cutoff.Helpers;
using cutoff.Services;

namespace cutoff.Models;

public class ShowGridVM
{
    public List<Show> Shows { get; set; }

	public ShowGridVM(DataAccessor dataAccessor, ShowService showService, string userName, int networkId, int genreId, int languageId)
	{
		Shows = showService.BuildShowGrid(userName, networkId, genreId, languageId);
	}
}

