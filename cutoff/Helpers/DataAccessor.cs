using System;
using cutoff.Models;

namespace cutoff.Helpers;

public class DataAccessor : IDataAccessor
{
    public DataAccessor()
    {
    }

    public List<EpisodeDTO> GetEpisodes()
    {
        using (var context = new DataContext())
        {
            List<EpisodeDTO> results = new List<EpisodeDTO>(); ;
            var episodes = context.Episodes.AsQueryable();
            results.AddRange(episodes);
            return results;
        }
    }

    public List<GenreDTO> GetGenres()
    {
        using (var context = new DataContext())
        {
            List<GenreDTO> results = new List<GenreDTO>(); ;
            var genres = context.Genres.AsQueryable();
            results.AddRange(genres);
            return results;
        }
    }

    public List<LanguageDTO> GetLanguages()
    {
        using (var context = new DataContext())
        {
            List<LanguageDTO> results = new List<LanguageDTO>(); ;
            var languages = context.Languages.AsQueryable();
            results.AddRange(languages);
            return results;
        }
    }

    public List<NetworkDTO> GetNetworks()
    {
        using (var context = new DataContext())
        {
            List<NetworkDTO> results = new List<NetworkDTO>(); ;
            var networks = context.Networks.AsQueryable();
            results.AddRange(networks);
            return results;
        }
    }

    public List<SeasonDTO> GetSeasons()
    {
        using (var context = new DataContext())
        {
            List<SeasonDTO> results = new List<SeasonDTO>(); ;
            var seasons = context.Seasons.AsQueryable();
            results.AddRange(seasons);
            return results;
        }
    }

    public List<ShowDTO> GetShows()
    {
        using (var context = new DataContext())
        {
            List<ShowDTO> results = new List<ShowDTO>(); ;
            var shows = context.Shows.AsQueryable();
            results.AddRange(shows);
            return results;
        }
    }

    public List<ShowEpisodeDTO> GetShowEpisodes()
    {
        using (var context = new DataContext())
        {
            List<ShowEpisodeDTO> results = new List<ShowEpisodeDTO>(); ;
            var showEpisodes = context.ShowEpisodes.AsQueryable();
            results.AddRange(showEpisodes);
            return results;
        }
    }

    public List<ShowGenreDTO> GetShowGenres()
    {
        using (var context = new DataContext())
        {
            List<ShowGenreDTO> results = new List<ShowGenreDTO>(); ;
            var showGenres = context.ShowGenres.AsQueryable();
            results.AddRange(showGenres);
            return results;
        }
    }

    public List<ShowNetworkDTO> GetShowNetworks()
    {
        using (var context = new DataContext())
        {
            List<ShowNetworkDTO> results = new List<ShowNetworkDTO>(); ;
            var showNetworks = context.ShowNetworks.AsQueryable();
            results.AddRange(showNetworks);
            return results;
        }
    }

    public List<ShowSeasonDTO> GetShowSeasons()
    {
        using (var context = new DataContext())
        {
            List<ShowSeasonDTO> results = new List<ShowSeasonDTO>(); ;
            var showSeasons = context.ShowSeasons.AsQueryable();
            results.AddRange(showSeasons);
            return results;
        }
    }

    public List<UserDTO> GetUsers()
    {
        using (var context = new DataContext())
        {
            List<UserDTO> results = new List<UserDTO>(); ;
            var users = context.Users.AsQueryable();
            results.AddRange(users);
            return results;
        }
    }

    public List<UserShowDTO> GetUserShows()
    {
        using (var context = new DataContext())
        {
            List<UserShowDTO> results = new List<UserShowDTO>(); ;
            var userShows = context.UserShows.AsQueryable();
            results.AddRange(userShows);
            return results;
        }
    }

    public List<UserShowEpisodeDTO> GetUserShowEpisodes()
    {
        using (var context = new DataContext())
        {
            List<UserShowEpisodeDTO> results = new List<UserShowEpisodeDTO>(); ;
            var userShowEpisodes = context.UserShowEpisodes.AsQueryable();
            results.AddRange(userShowEpisodes);
            return results;
        }
    }

    public void RegisterUser(UserDTO user)
    {
        using (var context = new DataContext())
        {
            context.Add(user);
            context.SaveChanges();
        }
    }

    public void ToggleShow(UserShowDTO userShow)
    {
        using (var context = new DataContext())
        {
            var availableUserShow = context.UserShows.Where(u => u.UserName == userShow.UserName
                                        && u.ShowId == userShow.ShowId).FirstOrDefault();
            if (availableUserShow != null)
                context.Remove(availableUserShow);
            else
                context.Add(userShow);
            context.SaveChanges();
        }
    }

    public void ToggleShowEpisode(UserShowEpisodeDTO userShowEpisode)
    {
        using (var context = new DataContext())
        {
            var availableUserShowEpisode = context.UserShowEpisodes.Where(u => u.UserName == userShowEpisode.UserName
                                               && u.ShowId == userShowEpisode.ShowId
                                               && u.SeasonNumber == userShowEpisode.SeasonNumber
                                               && u.EpisodeNumber == userShowEpisode.EpisodeNumber).FirstOrDefault();
            if (availableUserShowEpisode != null)
                context.Remove(availableUserShowEpisode);
            else
                context.Add(userShowEpisode);
            context.SaveChanges();
        }
    }
}

