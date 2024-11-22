using System.ComponentModel.DataAnnotations;
using store.Enum;

namespace store.Dtos.Authentication
{
    public class CreateProfileDto
    {
        [Required(ErrorMessage = "Nombre obligatorio.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s'-]+$", ErrorMessage = "Solo letras y caracteres especiales.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Apellido obligatorio.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s'-]+$", ErrorMessage = "Solo letras y caracteres especiales.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Correo obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo inválido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Contraseña obligatoria.")]
        [MinLength(6, ErrorMessage = "Mínimo 6 caracteres.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public required string Password { get; set; }

        public Role? Rol { get; set; } = Role.Employee;
    }
}
