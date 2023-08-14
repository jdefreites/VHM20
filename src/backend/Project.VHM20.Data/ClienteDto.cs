namespace Project.VHM20.Data
{
    public class ClienteDto
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DocumentoIdentidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
