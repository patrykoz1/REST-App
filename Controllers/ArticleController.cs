using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApp.Data;
using RestApp.Dtos;
using RestApp.Models;

namespace RestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _repository;
        private readonly IMapper _mapper;
        public ArticleController(IArticleRepository articleRepository,IMapper mapper)
        {
            _repository = articleRepository;
            _mapper = mapper;
        }
        // GET: api/Article
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var arts = await _repository.GetArticles();

            var mapped_arts = _mapper.Map<List<ArticleReadDto>>(arts);
            return Ok(mapped_arts);
        }

        // GET: api/Article/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var item =   await _repository.GetArticle(id);
            if(item == null)
            {
                return NotFound(item);
            }
            var mapped_item = _mapper.Map<ArticleReadDto>(item);
            return  Ok(item);
        }

        // POST: api/Article
        [HttpPost]
        public async Task<IActionResult> Post(ArticleAddDto article)
        {
            var art_model = _mapper.Map<Article>(article);
            await _repository.AddArticle(art_model);

            return Ok();
        }

        // PUT: api/Article/5
        [HttpPut("{id}")]
        public async Task<IActionResult>Put(int id, ArticleAddDto article)
        {
            var art = await _repository.GetArticle(id);
            // var art_model = _mapper.Map<Article>(article);
            await _repository.AddArticle(art);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
