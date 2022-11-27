using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PodcastApp.WebUI.Models
{
    public class EpisodeViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public int PodcastId { get; set; }


        public string Order { get; set; }

        public string FilePath { get; set; }
    }
}
