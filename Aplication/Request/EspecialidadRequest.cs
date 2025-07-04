namespace Application.Request
{
    public class EspecialidadRequest
    {
        public int id_especialidad { get; set; }

        public char cod_especialidad { get; set; }

        public string descripcion { get; set; }

        public byte[] rowversion { get; set; }
    }
}
