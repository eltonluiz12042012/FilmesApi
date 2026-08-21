using System.ComponentModel.DataAnnotations;

namespace FilmesApi.models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage ="O nome do logradouro é obrigatório")]
    public string Logradouro { get; set; }
    public int Numero { get; set; }
    public virtual Cinema Cinema { get; set; } 
}
