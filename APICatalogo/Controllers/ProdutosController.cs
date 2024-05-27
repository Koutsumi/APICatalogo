using APICatalogo.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;
[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{

    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("first")]
    public ActionResult<Produto>GetPrimeiro()
    { 
        var produto = _context.Produtos?.FirstOrDefault();
        if(produto is null) return NotFound("Produto não encontrado");
        return produto;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>>Get()
    { 
        var produtos = _context.Produtos?.ToList();
        if(produtos is null) return NotFound("Produtos não encontrados");
        return produtos;
    }

    [HttpGet("{id:int}", Name="ObterProduto")]
    public ActionResult<Produto> Get(int id) 
    {
        var produtos = _context.Produtos?.FirstOrDefault(p => p.ProdutoId == id);
        if (produtos is null) return NotFound("Produto não encontrado");
        return produtos;
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        if (produto is null) return BadRequest();

        _context.Produtos?.Add(produto);
        _context.SaveChanges();
        //O CreatedAtRouteResult também inclui um local no cabeçalho da resposta que aponta para onde o novo produto pode ser acessado, usando a rota chamada “obterProduto” e passando o ID do produto como parâmetro.
        return new CreatedAtRouteResult("obterProduto", new { id = produto.ProdutoId }, produto);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        if (id != produto.ProdutoId) return BadRequest();

        _context.Entry(produto).State= EntityState.Modified;
        _context.SaveChanges();
        return Ok(produto);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        //var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId==id);
        var produto = _context.Produtos?.Find(id);
        if (produto is null) return NotFound("Produto não encontrado");
        _context.Produtos?.Remove(produto);
        _context.SaveChanges();
        return Ok(produto);
    }

}
