namespace OrganizadorDeGastosPersonales.Librerias.Entidades
{
    public class Gasto
    {
        public const string NombreTabla = "Gasto";
        public int IdGasto { get; set; }
        public int IdCliente { get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; }
        public int Prioridad { get; set; }
        public bool Habilitado { get; set; }
        public DateTime FechaGasto { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
