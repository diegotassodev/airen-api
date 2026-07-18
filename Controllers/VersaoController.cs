using AirenApi.Data;
using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirenApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VersaoController : ControllerBase {

    private AirenContext _context;
    private IMapper _mapper;

    public VersaoController(AirenContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaVersao([FromBody] CreateVersaoDto versaoDto) {
        var versao = _mapper.Map<Versao>(versaoDto);
        _context.Versoes!.Add(versao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaVersaoPorId), new {Id = versao.Id}, versaoDto);
    }

    [HttpGet]
    public IEnumerable<ReadVersaoDto> VerVersoes() {
        var listaVersoesNaoMapeada = _context.Versoes?.ToList();
        var listaVersoes = _mapper.Map<List<ReadVersaoDto>>(listaVersoesNaoMapeada);
        return listaVersoes;
    }

    [HttpGet("{id}")]
    public IActionResult BuscaVersaoPorId(int id) {
        var versao = _mapper.Map<ReadVersaoDto>(_context.Versoes?.First(v => v.Id == id));
        if (versao == null) return NotFound();
        else return Ok(versao);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaVersao(int id, [FromBody] UpdateVersaoDto versaoDto) {
        var versao = _context.Versoes?.First(v => v.Id == id);
        if (versao == null) return NotFound();

        _mapper.Map(versaoDto, versao);
        _context.SaveChanges();

        return NoContent();
    } 

    [HttpDelete("{id}")]
    public IActionResult DeletaVersao (int id) {
        var versao = _context.Versoes?.First(v => v.Id == id);
        if (versao == null) return NotFound();

        _context.Versoes!.Remove(versao);
        _context.SaveChanges();

        return NoContent();
    }
}