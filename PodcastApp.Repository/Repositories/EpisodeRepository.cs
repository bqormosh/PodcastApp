using PodcastApp.Domain.Interfaces;
using PodcastApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace PodcastApp.Repository
{
    public class EpisodeRepository : GenericRepository<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(ApplicationDbContext context) : base(context)
        {

        }
        public Task<IEnumerable<Episode>> GetEpisodeByName(string episodeName)
        {
            return null;
        }


    }
}
