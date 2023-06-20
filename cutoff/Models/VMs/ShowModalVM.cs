using System;
using cutoff.Helpers;
using cutoff.Services;

namespace cutoff.Models;

public class ShowModalVM
{
    public Show Show { get; set; }

    public ShowModalVM(DataAccessor dataAccessor, ShowService showService, string userName, int showId)
    {
        Show = showService.BuildShowModal(userName, showId);
    }
}