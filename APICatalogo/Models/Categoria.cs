using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;

[Table("Categorias")]
public class Categoria
{
    // Inicialização da coleção para evitar referências nulas
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }

    [Key]
    public int CategoriaId { get; set; }
    
    // O '?' indica que o valor pode ser nulo

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    // Define a relação de 1 para muitos com a classe Produto
    public ICollection<Produto>? Produtos { get; set; }
}
