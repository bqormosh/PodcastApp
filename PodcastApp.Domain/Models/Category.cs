using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PodcastApp.Domain.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("UserId")]
        public virtual string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
