using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Request
{
    public class EspecialidadUpdateRequest
    {
        [Required]
        [StringLength(15)]
        [RegularExpression("^[a-zA-ZÁÉÍÓÚÑáéíóúñ\\s]+$", ErrorMessage = "Solo se permiten letras y espacios")]

        public string descripcion { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("^[a-zA-ZÁÉÍÓÚÑáéíóúñ\\s]+$", ErrorMessage = "Solo se permiten letras y espacios")]

        public string RowVersion { get; set; }
    }
}
