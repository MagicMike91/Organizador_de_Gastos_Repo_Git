namespace OrganizadorDeGastosPersonales.Librerias.Entidades
{
    public class Cliente
    {
        public const string NombreTabla = "Cliente";
        public int IdCliente { get; set; }
        public int IdLogin { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public bool Habilitado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
