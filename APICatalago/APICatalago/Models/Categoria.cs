using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalago.Models;

public class Categoria
{

    public Categoria()
    {
        Produtos = new Collection<Produto>();   
    }
    public int Id  { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(80)]
    public string? ImagenUrl { get; set; }
    public ICollection<Produto>? Produtos { get; set; }

}
