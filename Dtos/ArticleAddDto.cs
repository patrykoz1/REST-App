using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Dtos
{
    public class ArticleAddDto
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String Title { get; set; }
        [Required]
        public String Content { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
