using RestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Data
{
    public interface IArticleRepository
    {
        public   Task<IEnumerable<Article>> GetArticles();
        public   Task<Article> GetArticle(int id);
        public   Task AddArticle(Article article);
        public  Task DeleteArticle(int id);
        public Task EditArticle(int id);


    }
}
