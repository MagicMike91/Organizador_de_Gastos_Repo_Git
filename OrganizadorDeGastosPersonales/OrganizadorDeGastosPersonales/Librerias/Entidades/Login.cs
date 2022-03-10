namespace OrganizadorDeGastosPersonales.Librerias.Entidades
{
    public class Login
    {
        public const string NombreTabla = "Login";
        public int IdLogin { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public bool Habilitado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
