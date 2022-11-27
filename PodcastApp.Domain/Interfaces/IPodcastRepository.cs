using PodcastApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PodcastApp.Domain.Interfaces
{
    public interface IPodcastRepository : IGenericRepository<Podcast>
    {
        Task<IEnumerable<Podcast>> GetPodcastsByName(string podcastName);

        Task<IList<Podcast>> GetAllWithCategory();
    }
}
