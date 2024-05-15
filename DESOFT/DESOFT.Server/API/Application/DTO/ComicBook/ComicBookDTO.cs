using System.ComponentModel.DataAnnotations;

namespace DESOFT.Server.API.Application.DTO.ComicBook
{
    public class ComicBookDTO
    {
        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public int ComicBookId { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        [RegularExpression("^(\\d+\\.)?(\\d+\\.)?(\\*|\\d+)$", ErrorMessage = "A versão não se encontra no formato apropriado.")]
        public string Version { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public DateTime PublishingDate { get; set; }

        [Required(ErrorMessage = "O campo é '{0}' obrigatório")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "O campo '{0}' deve ser maior que {1}.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O campo é '{0}' obrigatório")]
        [MaxLength(20,ErrorMessage = "O campo é '{0}' deverá conter até 20 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo é '{0}' obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo é '{0}' deverá conter até 50 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo é '{0}' obrigatório")]
        [MaxLength(10, ErrorMessage = "O campo é '{0}' deverá conter até 10 caracteres.")]
        public string Author { get; set; }

    }
}
