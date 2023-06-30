using System;
using cutoff.Helpers;
using cutoff.Models;

namespace cutoff.Services;

public class NetworkService
{
	private readonly DataAccessor _dataAccessor;

	public NetworkService(DataAccessor dataAccessor)
	{
		_dataAccessor = dataAccessor;
	}

	public List<Network> BuildNetworkList()
	{
		var networks = _dataAccessor.GetNetworks().OrderBy(n => n.NetworkName).ToList();

        return ConvertToNetwork(networks);
	}

	public List<Network> ConvertToNetwork(List<NetworkDTO> networks)
	{
        List<Network> output = new List<Network>();

        foreach (var network in networks)
        {
            output.Add(new Network
            {
                NetworkId = network.NetworkId,
                NetworkName = network.NetworkName
            });
        }

        return output;
    }
}

