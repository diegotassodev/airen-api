using AirenApi.Data;
using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirenApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HabilidadeController : ControllerBase {

    private AirenContext _context;
    private IMapper _mapper;

    public HabilidadeController(AirenContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaHabilidade([FromBody] CreateHabilidadeDto habilidadeDto) {
        var habilidade = _mapper.Map<Habilidade>(habilidadeDto);
        _context.Habilidades!.Add(habilidade);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaHabilidadePorId), new {Id = habilidade.Id}, habilidadeDto);
    }

    [HttpGet]
    public IEnumerable<ReadHabilidadeDto> VerHabilidades() {
        var listaHabilidadesNaoMapeada = _context.Habilidades?.ToList();
        var listaHabilidades = _mapper.Map<List<ReadHabilidadeDto>>(listaHabilidadesNaoMapeada);
        return listaHabilidades;
    }

    [HttpGet("{id}")]
    public IActionResult BuscaHabilidadePorId(int id) {
        var habilidade = _mapper.Map<ReadHabilidadeDto>(_context.Habilidades?.FirstOrDefault(h => h.Id == id));
        if (habilidade == null) return NotFound();
        else return Ok(habilidade);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaHabilidade(int id, [FromBody] UpdateHabilidadeDto habilidadeDto) {
        var habilidade = _context.Habilidades?.FirstOrDefault(h => h.Id == id);
        if (habilidade == null) return NotFound();

        _mapper.Map(habilidadeDto, habilidade);
        _context.SaveChanges();

        return NoContent();
    } 

    [HttpDelete("{id}")]
    public IActionResult DeletaHabilidade (int id) {
        var habilidade = _context.Habilidades?.FirstOrDefault(h => h.Id == id);
        if (habilidade == null) return NotFound();

        _context.Habilidades!.Remove(habilidade);
        _context.SaveChanges();

        return NoContent();
    }
}