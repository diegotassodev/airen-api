using AirenApi.Data;
using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirenApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CapituloController : ControllerBase {

    private AirenContext _context;
    private IMapper _mapper;

    public CapituloController(AirenContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaCapitulo([FromBody] CreateCapituloDto capituloDto) {
        var capitulo = _mapper.Map<Capitulo>(capituloDto);
        _context.Capitulos!.Add(capitulo);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaCapituloPorId), new {Id = capitulo.Id}, capituloDto);
    }

    [HttpGet]
    public IEnumerable<ReadCapituloDto> VerCapitulos() {
        var listaCapitulosNaoMapeada = _context.Capitulos?.ToList();
        var listaCapitulos = _mapper.Map<List<ReadCapituloDto>>(listaCapitulosNaoMapeada);
        return listaCapitulos;
    }

    [HttpGet("{id}")]
    public IActionResult BuscaCapituloPorId(int id) {
        var capitulo = _mapper.Map<ReadCapituloDto>(_context.Capitulos?.First(c => c.Id == id));
        if (capitulo == null) return NotFound();
        else return Ok(capitulo);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCapitulo(int id, [FromBody] UpdateCapituloDto capituloDto) {
        Console.WriteLine(capituloDto.Numero);
        var capitulo = _context.Capitulos?.First(c => c.Id == id);
        if (capitulo == null) return NotFound();

        _mapper.Map(capituloDto, capitulo);
        _context.SaveChanges();

        return NoContent();
    } 

    [HttpDelete("{id}")]
    public IActionResult DeletaCapitulo (int id) {
        var capitulo = _context.Capitulos?.First(c => c.Id == id);
        if (capitulo == null) return NotFound();

        _context.Capitulos!.Remove(capitulo);
        _context.SaveChanges();

        return NoContent();
    }
}