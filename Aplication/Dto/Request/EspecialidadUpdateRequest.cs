using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Request
{
    public class EspecialidadUpdateRequest
    {
        [Required]
        public string descripcion { get; set; }

        [Required]
        public string RowVersion { get; set; }
    }
}
