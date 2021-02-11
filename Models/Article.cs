using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Content { get; set; }

        public int CategoryId { get; set; }
    }
}
