namespace OficinaMecanicaAPI.Models.DTO
{
    public class UpdateClienteDto
    {
        public required string Nome { get; set; }
        public required string Apelido { get; set; }
        public string? Email { get; set; }
        public required string Telefone { get; set; }
    }
}
