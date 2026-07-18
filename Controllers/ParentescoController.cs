using AirenApi.Data;
using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirenApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParentescoController : ControllerBase {

    private AirenContext _context;
    private IMapper _mapper;

    public ParentescoController(AirenContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaParentesco([FromBody] CreateParentescoDto parentescoDto) {
        var parentesco = _mapper.Map<Parentesco>(parentescoDto);
        _context.Parentescos!.Add(parentesco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaParentescoPorId), new {Id = parentesco.Id}, parentescoDto);
    }

    [HttpGet]
    public IEnumerable<ReadParentescoDto> VerParentescos() {
        var listaParentescosNaoMapeada = _context.Parentescos?.ToList();
        var listaParentescos = _mapper.Map<List<ReadParentescoDto>>(listaParentescosNaoMapeada);
        return listaParentescos;
    }

    [HttpGet("{id}")]
    public IActionResult BuscaParentescoPorId(int id) {
        var parentesco = _mapper.Map<ReadParentescoDto>(_context.Parentescos?.First(p => p.Id == id));
        if (parentesco == null) return NotFound();
        else return Ok(parentesco);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaParentesco(int id, [FromBody] UpdateParentescoDto parentescoDto) {
        var parentesco = _context.Parentescos?.First(p => p.Id == id);
        if (parentesco == null) return NotFound();

        _mapper.Map(parentescoDto, parentesco);
        _context.SaveChanges();

        return NoContent();
    } 

    [HttpDelete("{id}")]
    public IActionResult DeletaParentesco (int id) {
        var parentesco = _context.Parentescos?.First(p => p.Id == id);
        if (parentesco == null) return NotFound();

        _context.Parentescos!.Remove(parentesco);
        _context.SaveChanges();

        return NoContent();
    }
}