using Microsoft.AspNetCore.Mvc;
using Music_Library_Backend_Project.Data;
using Music_Library_Backend_Project.Songs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Music_Library_Backend_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Songs
        [HttpGet]
        public IActionResult Get()
        {
            var songs = _context.Songs.ToList();
            return Ok(songs); 
                }

        // GET api/Songs/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var song = _context.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }
            return Ok(song);
        }

        // POST api/Songs
        [HttpPost]
        public IActionResult Post([FromBody] Song song)
        {
            _context.Songs.Add(song);
            _context.SaveChanges();
            return StatusCode(201, song);
        }

        // PUT api/Songs/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song song)
        {
            var songToUpdate = _context.Songs.Find(id);
            if (songToUpdate == null)
            {
                return NotFound();
            }
            songToUpdate.Title = song.Title;
            songToUpdate.Artist = song.Artist;
            songToUpdate.Album = song.Album;
            songToUpdate.ReleaseDate = song.ReleaseDate;
            songToUpdate.Genre = song.Genre;

            _context.Songs.Update(songToUpdate);
            _context.SaveChanges();

            return Ok(songToUpdate);
        }

        // DELETE api/<Songs>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {   
            var song = _context.Songs.Find(id);
            if (song == null)
            {
                return NotFound(new);
            }

            _context.Songs.Remove(song);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
