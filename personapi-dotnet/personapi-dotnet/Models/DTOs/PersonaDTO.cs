namespace personapi_dotnet.Models.DTOs
{
    public class PersonaDTO
    {
        public int Cc { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public int? Edad { get; set; }
    }
}
