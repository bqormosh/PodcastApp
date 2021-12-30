using System;
using System.Collections.Generic;
using System.Text;

namespace PodcastApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPodcastRepository Podcasts { get; }
        int Complete();
    }
}
