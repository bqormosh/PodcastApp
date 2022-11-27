using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PodcastApp.Domain.Models
{
    public class Episode
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Order { get; set; }

        public string FilePath { get; set; }

        [ForeignKey("PodcastId")]
        public virtual int PodcastId { get; set; }
        public virtual Podcast Podcast { get; set; }


        [ForeignKey("UserId")]
        public virtual string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
