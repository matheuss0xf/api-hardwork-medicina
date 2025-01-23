using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Dto.User
{
    public static class UserDtos
    {
        public class UserAddDto
        {
            [Required(ErrorMessage = "O nome é obrigatório.")]
            [MaxLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "O e-mail é obrigatório.")]
            [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
            [MaxLength(256, ErrorMessage = "O e-mail não pode exceder 256 caracteres.")]
            public string Email { get; set; }
        }

        public class UserUpdateDto
        {
            [Required(ErrorMessage = "O nome é obrigatório.")]
            [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "O e-mail é obrigatório.")]
            [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
            [StringLength(255, ErrorMessage = "O e-mail deve ter no máximo 255 caracteres.")]
            public string Email { get; set; }
        }

        public class UserPatchDto
        {
            [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
            public string? Name { get; set; }

            [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
            [StringLength(255, ErrorMessage = "O e-mail deve ter no máximo 255 caracteres.")]
            public string? Email { get; set; }
        }

        public class UserResponseDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime CreatedAt { get; set; }
        }
    }
}