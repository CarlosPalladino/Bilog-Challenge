using System.ComponentModel.DataAnnotations;
namespace Application.Dto.Request
{
    public class EspecialidadRequest
    {
        [Required(ErrorMessage = "el cod_especialidad es requerido")]
        [StringLength(5, ErrorMessage = "Debe tener como máximo 5 caracteres")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números")]
        public string cod_especialidad { get; set; }

        [Required(ErrorMessage = "la descripcion es requerida")]
        [StringLength(5)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números")]
        public string descripcion { get; set; }

    }
}
