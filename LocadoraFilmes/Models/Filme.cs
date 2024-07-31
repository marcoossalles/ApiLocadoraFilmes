using System.ComponentModel.DataAnnotations;

namespace LocadoraFilmes.Models;

public class Filme
{
    [Required]
    [Key]
    public int filmeId { get; set; }

    [Required(ErrorMessage = "O titulo do filme e obtigatorio")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O genero do filme e obtigatorio")]
    public string Genero { get; set; }

    [Required]
    [Range(70, 200, ErrorMessage ="A duração deve ser entre 70 a 200")]
    public string Duracao { get; set;}
    
}
