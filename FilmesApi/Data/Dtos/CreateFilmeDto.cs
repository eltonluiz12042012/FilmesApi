using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class CreateFilmeDto
{
    [Required(ErrorMessage = "A informação do título é obrigatória")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "O genero é obrigatório")]
    [StringLength(50, ErrorMessage = "O gênero de ter no máximo 50 caracteres")]
    public string? Genero { get; set; }

    [Required(ErrorMessage = "A duração é obrigatória")]
    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
    public int Duracao { get; set; }
}
