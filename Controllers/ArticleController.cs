using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(IArticleRepository articleRepository,IMapper mapper, ILogger<ArticleController> logger)
        {
            _repository = articleRepository;
            _mapper = mapper;
            _logger = logger;
        }


        // GET: api/Article
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var arts = await _repository.GetArticles();

            var mapped_arts = _mapper.Map<List<ArticleReadDto>>(arts);
            return Ok(mapped_arts);
        }

        // GET: api/Article/5
        [Authorize]
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
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(ArticleAddDto article)
        {
            var art_model = _mapper.Map<Article>(article);
            await _repository.AddArticle(art_model);

            return Ok();
        }

        // PUT: api/Article/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateArticle(int id, ArticleUpdateDto article)
        {
            var art = await _repository.GetArticle(id);
            if(art == null)
            {
                return NotFound(art);
            }
            _mapper.Map(article,art);
            await _repository.EditArticle(art);
           

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteArticle(id);
            return Ok();
        }
    }
}
