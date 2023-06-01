using System;
using cutoff.Models;

namespace cutoff.Helpers;

public class DataAccessor : IDataAccessor
{
    public DataAccessor()
    {
    }

    public List<Episode> GetEpisodes()
    {
        using (var context = new DataContext())
        {
            List<Episode> results = new List<Episode>(); ;
            var episodes = context.Episodes.AsQueryable();
            results.AddRange(episodes);
            return results;
        }
    }

    public List<Genre> GetGenres()
    {
        using (var context = new DataContext())
        {
            List<Genre> results = new List<Genre>(); ;
            var genres = context.Genres.AsQueryable();
            results.AddRange(genres);
            return results;
        }
    }

    public List<Network> GetNetworks()
    {
        using (var context = new DataContext())
        {
            List<Network> results = new List<Network>(); ;
            var networks = context.Networks.AsQueryable();
            results.AddRange(networks);
            return results;
        }
    }

    public List<Season> GetSeasons()
    {
        using (var context = new DataContext())
        {
            List<Season> results = new List<Season>(); ;
            var seasons = context.Seasons.AsQueryable();
            results.AddRange(seasons);
            return results;
        }
    }

    public List<Show> GetShows()
    {
        using (var context = new DataContext())
        {
            List<Show> results = new List<Show>(); ;
            var shows = context.Shows.AsQueryable();
            results.AddRange(shows);
            return results;
        }
    }

    public List<ShowEpisode> GetShowEpisodes()
    {
        using (var context = new DataContext())
        {
            List<ShowEpisode> results = new List<ShowEpisode>(); ;
            var showEpisodes = context.ShowEpisodes.AsQueryable();
            results.AddRange(showEpisodes);
            return results;
        }
    }

    public List<ShowGenre> GetShowGenres()
    {
        using (var context = new DataContext())
        {
            List<ShowGenre> results = new List<ShowGenre>(); ;
            var showGenres = context.ShowGenres.AsQueryable();
            results.AddRange(showGenres);
            return results;
        }
    }

    public List<ShowNetwork> GetShowNetworks()
    {
        using (var context = new DataContext())
        {
            List<ShowNetwork> results = new List<ShowNetwork>(); ;
            var showNetworks = context.ShowNetworks.AsQueryable();
            results.AddRange(showNetworks);
            return results;
        }
    }

    public List<ShowSeason> GetShowSeasons()
    {
        using (var context = new DataContext())
        {
            List<ShowSeason> results = new List<ShowSeason>(); ;
            var showSeasons = context.ShowSeasons.AsQueryable();
            results.AddRange(showSeasons);
            return results;
        }
    }
}

