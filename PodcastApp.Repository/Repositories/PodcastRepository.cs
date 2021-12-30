using PodcastApp.Domain.Interfaces;
using PodcastApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PodcastApp.Repository
{
    public class PodcastRepository : GenericRepository<Podcast>, IPodcastRepository
    {
        public PodcastRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Task<IEnumerable<Podcast>> GetPodcastsByName(string podcastName)
        {
            return null;
        }


    }
}
