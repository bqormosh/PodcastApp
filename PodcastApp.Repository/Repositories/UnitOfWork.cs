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

        public UnitOfWork(ApplicationDbContext podcastAppDbContext,
            IPodcastRepository podcastRepository)
        {
            this._context = podcastAppDbContext;

            this.Podcasts = podcastRepository;
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
