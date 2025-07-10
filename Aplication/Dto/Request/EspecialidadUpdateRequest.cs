using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Request
{
    public class EspecialidadUpdateRequest
    {
        [Required(ErrorMessage = "la descripcion es requerida")]
        [StringLength(5, ErrorMessage = "Debe tener como máximo 5 caracteres")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "la rowVersion es requerida")]
        [StringLength(50)]
        [RegularExpression("^[a-zA-ZÁÉÍÓÚÑáéíóúñ\\s]+$", ErrorMessage = "Solo se permiten letras y espacios")]

        public string RowVersion { get; set; }
    }
}
