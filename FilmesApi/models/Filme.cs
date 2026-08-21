using System.ComponentModel.DataAnnotations;

namespace FilmesApi.models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage ="A informação do título é obrigatória")]
    public string? Titulo { get; set; }
    
    [Required(ErrorMessage ="O genero é obrigatório")]
    [MaxLength(50, ErrorMessage ="O gênero de ter no máximo 50 caracteres")]
    public string? Genero { get; set; }

    [Required(ErrorMessage ="A duração é obrigatória")]
    [Range(70,600, ErrorMessage ="A duração deve ter entre 70 e 600 minutos")]
    public int Duracao { get; set; }
}
