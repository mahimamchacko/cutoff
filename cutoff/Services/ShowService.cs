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

    public List<Show> BuildShows(List<ShowDTO> shows, List<NetworkDTO> networks, List<ShowNetworkDTO> showNetworks)
    {
        List<Show> output = new List<Show>();
        foreach (var show in shows.OrderBy(s => s.ShowName))
        {
            var availableNetworks = showNetworks.Where(s => s.ShowId == show.ShowId).Select(n => n.NetworkId);
            output.Add(new Show
            {
                ShowId = show.ShowId,
                ShowName = show.ShowName,
                ShowDescription = show.ShowDescription,
                Networks = networks.Where(n => availableNetworks.Contains(n.NetworkId)).ToList()
            });
        }
        return output;
    }
}

