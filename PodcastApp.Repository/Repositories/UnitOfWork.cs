using PodcastApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodcastApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IPodcastRepository Podcasts { get; }
        public ICategoryRepository Categories { get; }
        public IEpisodeRepository Episodes { get; }
        public UnitOfWork(ApplicationDbContext podcastAppDbContext,
                    IPodcastRepository podcastRepository,
                    ICategoryRepository categoryRepository,
                    IEpisodeRepository episodeRepository
                    )
        {
            this._context = podcastAppDbContext;

            this.Podcasts = podcastRepository;
            this.Categories = categoryRepository;
            this.Episodes = episodeRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
