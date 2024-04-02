using HMDB_API.Data;
using HMDB_API.Models;
using HMDB_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HMDB_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/HMDBAPI")]
    [ApiController]
    public class HMDBAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<MovieDTO>> GetMovies()
        {
            return Ok(MovieStore.movieList);
        }

        [HttpGet("{id:int}",Name ="GetMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MovieDTO> GetMovie(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var movie = MovieStore.movieList.FirstOrDefault(u => u.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MovieDTO> CreateMovie([FromBody]MovieDTO movie)
        {
            if (MovieStore.movieList.FirstOrDefault(u => u.Name.ToLower() == movie.Name.ToLower())!=null)
            {
                ModelState.AddModelError("CustomError", "Movie already exists!");
                return BadRequest(ModelState);
            }
            if (movie == null)
            {
                return BadRequest(movie);
            }
            if (movie.Id > 0) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            movie.Id = MovieStore.movieList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            MovieStore.movieList.Add(movie);
            return CreatedAtRoute("GetMovie",new {id = movie.Id},movie);
        }

        [HttpDelete("{id:int}", Name = "DeleteMovie")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteMovie(int id)
        {
            if (id == 0) 
            {
                return BadRequest();
            }
            var movie = MovieStore.movieList.FirstOrDefault(u => u.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            MovieStore.movieList.Remove(movie);
            return NoContent(); 
        }

        [HttpPut("{id:int}", Name = "UpdateMovie")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateMovie(int id, [FromBody]MovieDTO moviedto)
        {
            if (moviedto == null || id != moviedto.Id)
            {
                return BadRequest();
            }
            var movie = MovieStore.movieList.FirstOrDefault(u => u.Id == id);
            movie.Name=moviedto.Name;
            movie.Director=moviedto.Director;
            movie.Rating=moviedto.Rating;   

            return NoContent();

        }
    }
}
