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
        [HttpPost("/create")]
        public JsonResult Create(MovieApi movie)
        {
            _context.Movies.Add(movie);
            //save change
            _context.SaveChanges();

            return new JsonResult(Ok(movie));
        }
        //list all Movie
        [HttpGet("/getall")]
        public JsonResult GetAll()
        {
            var result = _context.Movies.ToList();
            return new JsonResult(Ok(result));
        }
        //list one movie
        [HttpGet("/getid/{id}")]
        public JsonResult GetById(int id)
        {
            var result = _context.Movies.ToList().FirstOrDefault(m => m.Id == id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(result));
        }
        //edit movie
        [HttpPut("/update")]
        public JsonResult Update(MovieApi movie)
        {
            var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == movie.Id);
            if (movieInDb == null)
            {
                return new JsonResult(NotFound());
            }
            movieInDb.MovieType = movie.MovieType;
            movieInDb.MovieName = movie.MovieName;
            
            //save changes
            _context.SaveChanges();
            
            return  new JsonResult(Ok(movie));
        }
        //delete
        [HttpDelete("/delete/{id}")]
        public JsonResult Delete(int id)
        {
            var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movieInDb==null)
            {
                return new JsonResult(NotFound());
            }
            //delete movie
            _context.Movies.Remove(movieInDb);
            
            //save
            _context.SaveChanges();
            return new JsonResult(Ok(movieInDb));
        }
    }
}