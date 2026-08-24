using Microsoft.AspNetCore.Mvc;
using FilmesApi.models;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
namespace FilmesApi.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
    {

        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetFilmeId), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> GetFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmeId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateFilme(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null) return NotFound();

        var filmaParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmaParaAtualizar, ModelState);
        if (!TryValidateModel(filmaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmaParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFilme(int id)
    {
        Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }

}
