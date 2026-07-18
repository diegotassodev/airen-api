using AirenApi.Data;
using AirenApi.Data.DTOs;
using AirenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirenApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VolumeController : ControllerBase {

    private AirenContext _context;
    private IMapper _mapper;

    public VolumeController(AirenContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaVolume([FromBody] CreateVolumeDto volumeDto) {
        var volume = _mapper.Map<Volume>(volumeDto);
        _context.Volumes!.Add(volume);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaVolumePorId), new {Id = volume.Id}, volumeDto);
    }

    [HttpGet]
    public IEnumerable<ReadVolumeDto> VerVolumes () {
        var listaVolumesNaoMapeados = _context.Volumes?.ToList();
        var listaVolumes = _mapper.Map<List<ReadVolumeDto>>(listaVolumesNaoMapeados);
        return listaVolumes;
    }

    [HttpGet("{id}")]
    public IActionResult BuscaVolumePorId(int id) {
        var volume = _mapper.Map<ReadVolumeDto>(_context.Volumes?.First(v => v.Id == id));
        if (volume == null) return NotFound();
        else return Ok(volume);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaVolume(int id, [FromBody] UpdateVolumeDto volumeDto) {
        var volume = _context.Volumes?.First(v => v.Id == id);
        if (volume == null) return NotFound();

        _mapper.Map(volumeDto, volume);
        _context.SaveChanges();

        return NoContent();
    } 

    [HttpDelete("{id}")]
    public IActionResult DeletaVolume (int id) {
        var volume = _context.Volumes?.First(v => v.Id == id);
        if (volume == null) return NotFound();

        _context.Volumes!.Remove(volume);
        _context.SaveChanges();

        return NoContent();
    }
}