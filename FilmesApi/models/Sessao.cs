using System.ComponentModel.DataAnnotations;

namespace FilmesApi.models;

public class Sessao
{
    [Key]
    [Required]
    public int Id { get; set; }

}
