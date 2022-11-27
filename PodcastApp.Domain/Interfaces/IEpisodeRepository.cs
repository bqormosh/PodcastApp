using PodcastApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PodcastApp.Domain.Interfaces
{
    public interface IEpisodeRepository : IGenericRepository<Episode>
    {
        Task<IEnumerable<Episode>> GetEpisodeByName(string episodeName);
    }
}

