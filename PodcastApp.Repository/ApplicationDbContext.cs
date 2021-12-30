using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PodcastApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodcastApp.Repository
{
    public class ApplicationDbContext :IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Podcast> Podcasts { get; set; }


    }

}
