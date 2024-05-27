using APICatalogo.Models;
using APICatalogo.Models.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;
[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{

    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        try {
            
            var categorias = _context.Categorias?.AsNoTracking().ToList();
            return categorias;

        } catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar sua soicitação"); }

    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {

        var categoria = _context.Categorias?.AsNoTracking().FirstOrDefault(p => p.CategoriaId == id);
        if (categoria is null) return NotFound($"Categoria id{id} não encontrada");
        return categoria;

    }

    [HttpGet("produtos")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
    { 
        var lista = _context.Categorias?.Include(p => p.Produtos).ToList(); 
        return lista;
    
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        _context.Categorias?.Add(categoria);
        _context.SaveChanges();
        return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id,Categoria categoria)
    {
        if (id != categoria.CategoriaId) return BadRequest();

        _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        
        var categoria = _context.Categorias?.Find(id);
        if (categoria is null) return NotFound("Categoria não encontrada");
        _context.Categorias?.Remove(categoria);
        _context.SaveChanges();
        return Ok(categoria);
    }


}
