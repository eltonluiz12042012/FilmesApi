using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FilmesApi.Controllers;


[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        var endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = endereco.Id }, endereco);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaEnderecosPorId(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }
        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoDto);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> RecuperarEnderecos()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }
       _mapper.Map(endereco, enderecoDto);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateEndereco(int id, JsonPatchDocument<UpdateEnderecoDto> patch)
    {
        Endereco? endereco = _context.Enderecos.FirstOrDefault(f => f.Id == id);
        if (endereco is null) return NotFound();

        var enderecoParaAtualizar = _mapper.Map<UpdateEnderecoDto>(endereco);
        patch.ApplyTo(enderecoParaAtualizar, ModelState);
        if (!TryValidateModel(enderecoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(enderecoParaAtualizar, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if(endereco is null)
        {
            return NotFound();
        }
        _context.Remove(endereco);
        _context.SaveChanges();
        return NoContent();

    }


}
