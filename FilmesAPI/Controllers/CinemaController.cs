using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        public CinemaController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return Ok();

            //return CreatedAtAction(nameof(RecuperaCinemaPorId), new {Id=cinema.Id},cinema);
            
        }

        [HttpGet]
        public IActionResult RecuperaCinema([FromQuery] string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null)
            {
                return NotFound();
            }
            if(!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas 
                        where cinema.Sessoes.Any(sessao=>sessao.Filme.Titulo==nomeDoFilme)
                        select cinema;
                cinemas = query.ToList();
            }
            List<ReadCinemaDto> readDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);
            return Ok(readDto);
            //return _context.Cinemas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(c=>c.Id== id);
            if (cinema == null) return NotFound();
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
