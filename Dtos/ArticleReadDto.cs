using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Dtos
{
    public class ArticleReadDto
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public int CategoryId { get; set; }
    }
}
