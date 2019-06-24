using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Interfaces;
using TodoAPI.Models;
using Newtonsoft.Json.Serialization;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET: api/authors
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorRepository.List());
        }

        // GET api/authors/about
        [HttpGet("About")]
        public ContentResult About()
        {
            return Content("An API listing authors of docs.asp.net.");
        }

        // GET api/authors/version
        [HttpGet("version")]
        public string Version()
        {
            return "Version 1.0.0";
        }

        // GET: api/authors/search?namelike=th
        [HttpGet("Search")]
        public IActionResult Search(string namelike)
        {
            var result = _authorRepository.GetByNameSubstring(namelike);
            if (!result.Any())
            {
                return NotFound(namelike);
            }
            return Ok(result);
        }

        // GET api/authors/ardalis
        [HttpGet("{alias}")]
        public Author Get(string alias)
        {
            return _authorRepository.GetByAlias(alias);
        }

        
    }
}