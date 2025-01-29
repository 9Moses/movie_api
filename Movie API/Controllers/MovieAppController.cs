using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Movie_API.Data;
using Movie_API.Models;

namespace Movie_API.Controllers
{
[Route("[controller]/[action]")]
[ApiController]
    public class MovieAppController : ControllerBase
    {
        private readonly ApiContext _context;

        public MovieAppController(ApiContext context)
        {
            _context = context;
        }
        
        //crete Movie
        [HttpPost]
        public JsonResult Create(MovieApi movie)
        {
            _context.Movies.Add(movie);
            //save change
            _context.SaveChanges();

            return new JsonResult(Ok(movie));
        }
        //list all Movie
        //list one movie
        //edit
        //delete
    }
}