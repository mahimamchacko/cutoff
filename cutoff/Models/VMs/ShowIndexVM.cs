using System;
using cutoff.Helpers;
using cutoff.Services;

namespace cutoff.Models;

public class ShowIndexVM
{
    public List<Genre> Genres { get; set; }
    public List<LanguageDTO> Languages { get; set; }
    public List<Network> Networks { get; set; }

    public ShowIndexVM(DataAccessor dataAccessor, NetworkService networkService, GenreService genreService, string userName)
    {
        Genres = genreService.BuildGenreList();
        Languages = dataAccessor.GetLanguages();
        Networks = networkService.BuildNetworkList();
    }
}

