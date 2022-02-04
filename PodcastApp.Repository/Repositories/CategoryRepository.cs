using PodcastApp.Domain.Interfaces;
using PodcastApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace PodcastApp.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {

        }
        public Task<IEnumerable<Category>> GetCategoryByName(string categoryName)
        {
            return null;
        }


    }
}
