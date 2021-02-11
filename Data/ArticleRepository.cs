using Microsoft.EntityFrameworkCore;
using RestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Data
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MyContext dbCon;
        public ArticleRepository(MyContext db)
        {
            dbCon = db;
        }
        public async Task AddArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            else
            {
                await dbCon.Articles.AddAsync(article);
                await dbCon.SaveChangesAsync();
            }
            
        }

        public async Task<Article> GetArticle(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else
            {
                return await dbCon.Articles.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await dbCon.Articles.ToListAsync();
        }

        public async Task DeleteArticle(int id)
        {
            var art = dbCon.Articles.FirstOrDefaultAsync(x => x.Id == id);
            dbCon.Remove(art);
            await dbCon.SaveChangesAsync();
        }

        public async Task EditArticle(int id)
        {
            var art = dbCon.Articles.FirstOrDefaultAsync(x => x.Id == id);
            dbCon.Remove(art);
            await dbCon.SaveChangesAsync();
        }


    }
}
