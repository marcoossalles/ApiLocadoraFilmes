using AutoMapper;
using LocadoraFilmes.Data;
using LocadoraFilmes.Data.Dto;
using LocadoraFilmes.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraFilmes.Controllers;

[ApiController]
[Route("[controller]")]

public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    //Estancia FilmeContext para FilmeController
    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto )
    {

        Filme filme = _mapper.Map<Filme>( filmeDto );

        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaFilmePorID), new {id = filme.filmeId}, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> BuscaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 38)
    { 
        return _context.Filmes.Skip(skip).Take(take); 
    }

    [HttpGet("{id}")]
    public IActionResult BuscaFilmePorID(int id)
    {
       var filme = _context.Filmes.FirstOrDefault(filme => filme.filmeId == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto) 
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.filmeId == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id, [FromBody] DeleteFilmeDto filmeDto) 
    {
        var filme = _context.Filmes.FirstOrDefault(filme=>filme.filmeId == id); 
        if (filme == null) return NotFound();
        _context.Filmes.Remove(filme);
        _context.SaveChanges();
        return NoContent();
        
    }
}
