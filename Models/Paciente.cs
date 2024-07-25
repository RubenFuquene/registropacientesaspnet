namespace pacientes.Models
{
    //Entidad que representa el paciente en la BD
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public int Genero { get; set; }
        public string Direccion { get; set;}
        public string Telefono { get; set;}
        public DateTime FechaAdmision { get; set;}
    }
}
