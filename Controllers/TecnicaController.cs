using AirenApi.Data;
using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirenApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TecnicaController : ControllerBase {

    private AirenContext _context;
    private IMapper _mapper;

    public TecnicaController(AirenContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaTecnica([FromBody] CreateTecnicaDto tecnicaDto) {
        var tecnica = _mapper.Map<Tecnica>(tecnicaDto);
        _context.Tecnicas!.Add(tecnica);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaTecnicaPorId), new {Id = tecnica.Id}, tecnicaDto);
    }

    [HttpGet]
    public IEnumerable<ReadTecnicaDto> VerTecnicas() {
        var listaTecnicasNaoMapeada = _context.Tecnicas?.ToList();
        var listaTecnicas = _mapper.Map<List<ReadTecnicaDto>>(listaTecnicasNaoMapeada);
        return listaTecnicas;
    }

    [HttpGet("{id}")]
    public IActionResult BuscaTecnicaPorId(int id) {
        var tecnica = _mapper.Map<ReadTecnicaDto>(_context.Tecnicas?.First(t => t.Id == id));
        if (tecnica == null) return NotFound();
        else return Ok(tecnica);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaTecnica(int id, [FromBody] UpdateTecnicaDto tecnicaDto) {
        var tecnica = _context.Tecnicas?.First(t => t.Id == id);
        if (tecnica == null) return NotFound();

        _mapper.Map(tecnicaDto, tecnica);
        _context.SaveChanges();

        return NoContent();
    } 

    [HttpDelete("{id}")]
    public IActionResult DeletaTecnica (int id) {
        var tecnica = _context.Tecnicas?.First(t => t.Id == id);
        if (tecnica == null) return NotFound();

        _context.Tecnicas!.Remove(tecnica);
        _context.SaveChanges();

        return NoContent();
    }
}