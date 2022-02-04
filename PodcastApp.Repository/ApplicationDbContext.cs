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
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<Category> PodcastsCategories { get; set; }

    }

    //public class ApplicationUser : IdentityUser
    //{
    //    [PersonalData]
    //    public string FirstName { get; set; }

    //    [PersonalData]
    //    public string LastName { get; set; }
    //}

}
