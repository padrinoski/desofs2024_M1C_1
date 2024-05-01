using System.ComponentModel.DataAnnotations;

namespace DESOFT.Server.API.Application.DTO.Login
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = "O campo é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessageResourceName = "O campo é obrigatório")]
        public string Password { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }

    }
}
