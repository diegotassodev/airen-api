using AirenApi.Data;
using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirenApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AfiliacaoController : ControllerBase {

    private AirenContext _context;
    private IMapper _mapper;

    public AfiliacaoController(AirenContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaAfiliacao([FromBody] CreateAfiliacaoDto afiliacaoDto) {
        var afiliacao = _mapper.Map<Afiliacao>(afiliacaoDto);
        _context.Afiliacaos!.Add(afiliacao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaAfiliacaoPorId), new {Id = afiliacao.Id}, afiliacaoDto);
    }

    [HttpGet]
    public IEnumerable<ReadAfiliacaoDto> VerAfiliacoes() {
        var listaAfiliacoesNaoMapeada = _context.Afiliacaos?.ToList();
        var listaAfiliacoes = _mapper.Map<List<ReadAfiliacaoDto>>(listaAfiliacoesNaoMapeada);
        return listaAfiliacoes;
    }

    [HttpGet("{id}")]
    public IActionResult BuscaAfiliacaoPorId(int id) {
        var afiliacao = _mapper.Map<ReadAfiliacaoDto>(_context.Afiliacaos?.First(a => a.Id == id));
        if (afiliacao == null) return NotFound();
        else return Ok(afiliacao);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaAfiliacao(int id, [FromBody] UpdateAfiliacaoDto afiliacaoDto) {
        var afiliacao = _context.Afiliacaos?.First(a => a.Id == id);
        if (afiliacao == null) return NotFound();

        _mapper.Map(afiliacaoDto, afiliacao);
        _context.SaveChanges();

        return NoContent();
    } 

    [HttpDelete("{id}")]
    public IActionResult DeletaAfiliacao (int id) {
        var afiliacao = _context.Afiliacaos?.First(a => a.Id == id);
        if (afiliacao == null) return NotFound();

        _context.Afiliacaos!.Remove(afiliacao);
        _context.SaveChanges();

        return NoContent();
    }
}