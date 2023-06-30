using System;
using cutoff.Helpers;
using cutoff.Services;

namespace cutoff.Models;

public class ShowIndexVM
{
    public List<Genre> Genres { get; set; }
    public List<Language> Languages { get; set; }
    public List<Network> Networks { get; set; }

    public ShowIndexVM(DataAccessor dataAccessor, NetworkService networkService, GenreService genreService, LanguageService languageService, string userName)
    {
        Genres = genreService.BuildGenreList();
        Languages = languageService.BuildLanguageList();
        Networks = networkService.BuildNetworkList();
    }
}

