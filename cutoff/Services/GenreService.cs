using System;
using cutoff.Helpers;
using cutoff.Models;

namespace cutoff.Services;

public class GenreService
{
    private readonly DataAccessor _dataAccessor;

    public GenreService(DataAccessor dataAccessor)
    {
        _dataAccessor = dataAccessor;
    }

    public List<Genre> BuildGenreList()
    {
        var genres = _dataAccessor.GetGenres().OrderBy(g => g.GenreName).ToList();

        return ConvertToGenre(genres);
    }

    public List<Genre> ConvertToGenre(List<GenreDTO> genres)
    {
        List<Genre> output = new List<Genre>();

        foreach (var genre in genres)
        {
            output.Add(new Genre
            {
                GenreId = genre.GenreId,
                GenreName = genre.GenreName
            });
        }

        return output;
    }
}

