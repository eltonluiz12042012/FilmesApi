using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperarCinemasPorId), new { Id = cinema.Id }, cinema);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarCinemasPorId(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema is not null)
        {
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }
        return NotFound();
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> RecuperaCinemas()
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema is not null)
        {
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCinema(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema is not null)
        {
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
        return NotFound();
    }
}
