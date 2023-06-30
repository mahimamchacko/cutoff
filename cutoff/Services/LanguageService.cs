using System;
using cutoff.Helpers;
using cutoff.Models;

namespace cutoff.Services;

public class LanguageService
{
    private readonly DataAccessor _dataAccessor;

    public LanguageService(DataAccessor dataAccessor)
    {
        _dataAccessor = dataAccessor;
    }

    public List<Language> BuildLanguageList()
    {
        var languages = _dataAccessor.GetLanguages().OrderBy(l => l.LanguageName).ToList();

        return ConvertToLanguage(languages);
    }

    public List<Language> ConvertToLanguage(List<LanguageDTO> languages)
    {
        List<Language> output = new List<Language>();

        foreach (var language in languages)
        {
            output.Add(new Language
            {
                LanguageId = language.LanguageId,
                LanguageName = language.LanguageName
            });
        }

        return output;
    }
}

