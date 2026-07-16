using AirenApi.Data;
using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirenApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PotentiaController : ControllerBase {

    private AirenContext _context;
    private IMapper _mapper;

    public PotentiaController(AirenContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaPotentia([FromBody] CreatePotentiaDto potentiaDto) {
        var potentia = _mapper.Map<Potentia>(potentiaDto);
        _context.Potentias!.Add(potentia);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaPotentiasPorId), new {Id = potentia.Id}, potentiaDto);
    }

    [HttpGet]
    public IEnumerable<ReadPotentiaDto> VerPotentias() {
        var listaPotentiasNaoMapeada = _context.Potentias?.ToList();
        var listaPotentias = _mapper.Map<List<ReadPotentiaDto>>(listaPotentiasNaoMapeada);
        return listaPotentias;
    }

    [HttpGet("{id}")]
    public IActionResult BuscaPotentiasPorId(int id) {
        var potentia = _context.Potentias?.First(p => p.Id == id);
        if (potentia == null) return NotFound();
        else return Ok(potentia);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaPotetia(int id, [FromBody] UpdatePotentiaDto potentiaDto) {
        var potentia = _context.Potentias!.First(p => p.Id == id);
        if (potentia == null) return NotFound();

        _mapper.Map(potentiaDto, potentia);
        _context.SaveChanges();

        return NoContent();
    } 

    [HttpDelete("{id}")]
    public IActionResult DeletaPotentia (int id) {
        var potentia = _context.Potentias!.First(p => p.Id == id);
        if (potentia == null) return NotFound();

        _context.Potentias!.Remove(potentia);
        _context.SaveChanges();

        return NoContent();
    }
}