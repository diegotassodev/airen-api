using AirenApi.Data;
using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirenApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonagemController : ControllerBase {

    private AirenContext _context;
    private IMapper _mapper;

    public PersonagemController(AirenContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaPersonagem([FromBody] CreatePersonagemDto personagemDto) {
        var personagem = _mapper.Map<Personagem>(personagemDto);
        _context.Personagens!.Add(personagem);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaPersonagensPorId), new {Id = personagem.Id}, personagemDto);
    }

    [HttpGet]
    public IEnumerable<ReadPersonagemDto> VerPersonagens() {
        var listaPersonagensNaoMapeada = _context.Personagens?.ToList();
        var listaPersonagens = _mapper.Map<List<ReadPersonagemDto>>(listaPersonagensNaoMapeada);
        return listaPersonagens;
    }

    [HttpGet("{id}")]
    public IActionResult BuscaPersonagensPorId(int id) {
        var personagem = _mapper.Map<ReadPersonagemDto>(_context.Personagens?.First(p => p.Id == id));
        if (personagem == null) return NotFound();
        else return Ok(personagem);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaPersonagem(int id, [FromBody] UpdatePersonagemDto personagemDto) {
        var personagem = _context.Personagens!.First(p => p.Id == id);
        if (personagem == null) return NotFound();

        _mapper.Map(personagemDto, personagem);
        _context.SaveChanges();

        return NoContent();
    } 

    [HttpDelete("{id}")]
    public IActionResult DeletaPersonagem (int id) {
        var personagem = _context.Personagens!.First(p => p.Id == id);
        if (personagem == null) return NotFound();

        _context.Personagens!.Remove(personagem);
        _context.SaveChanges();

        return NoContent();
    }
}