using AirenApi.Data;
using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirenApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HobbyController : ControllerBase {

    private AirenContext _context;
    private IMapper _mapper;

    public HobbyController(AirenContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaHobby([FromBody] CreateHobbyDto hobbyDto) {
        var hobby = _mapper.Map<Hobby>(hobbyDto);
        _context.Hobbies!.Add(hobby);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaHobbyPorId), new {Id = hobby.Id}, hobbyDto);
    }

    [HttpGet]
    public IEnumerable<ReadHobbyDto> VerHobbies() {
        var listaHobbiesNaoMapeada = _context.Hobbies?.ToList();
        var listaHobbies = _mapper.Map<List<ReadHobbyDto>>(listaHobbiesNaoMapeada);
        return listaHobbies;
    }

    [HttpGet("{id}")]
    public IActionResult BuscaHobbyPorId(int id) {
        var hobby = _mapper.Map<ReadHobbyDto>(_context.Hobbies?.First(h => h.Id == id));
        if (hobby == null) return NotFound();
        else return Ok(hobby);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaHobby(int id, [FromBody] UpdateHobbyDto hobbyDto) {
        var hobby = _context.Hobbies?.First(h => h.Id == id);
        if (hobby == null) return NotFound();

        _mapper.Map(hobbyDto, hobby);
        _context.SaveChanges();

        return NoContent();
    } 

    [HttpDelete("{id}")]
    public IActionResult DeletaHobby (int id) {
        var hobby = _context.Hobbies?.First(h => h.Id == id);
        if (hobby == null) return NotFound();

        _context.Hobbies!.Remove(hobby);
        _context.SaveChanges();

        return NoContent();
    }
}