using System.ComponentModel.DataAnnotations;
namespace Application.Dto.Request
{
    public class EspecialidadRequest
    {
        [Required]
        [StringLength(15)]
        [RegularExpression("^[a-zA-ZÁÉÍÓÚÑáéíóúñ\\s]+$", ErrorMessage = "Solo se permiten letras y espacios")]
        public string cod_especialidad { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("^[a-zA-ZÁÉÍÓÚÑáéíóúñ\\s]+$", ErrorMessage = "Solo se permiten letras y espacios")]
        public string descripcion { get; set; }

    }
}
