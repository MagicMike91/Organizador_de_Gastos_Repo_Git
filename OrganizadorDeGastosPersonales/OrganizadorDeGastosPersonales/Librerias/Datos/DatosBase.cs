using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace OrganizadorDeGastosPersonales.Librerias.Datos
{
    /// <summary>
    /// Clase base de la cual heredan todas las clases de accesos a datos
    /// </summary>
    public abstract class DatosBase : IDisposable
    {
        // TODO: Aplicar el patrón IDisposable

        private SqlConnection _connection = null;
        private bool _isPrivateConnection = false;

        #region Constructores
        /// <summary>
        /// Constructor default crea una conexion propia
        /// </summary>
        public DatosBase()
        {
            _connection = (SqlConnection)CrearConexion();
            _isPrivateConnection = true;
        }

        /// <summary>
        /// Constructor que suminstra una conexion que seguramente
        /// estará enlistada en una transacción con otros objetos
        /// </summary>
        public DatosBase(IDbConnection connection)
        {
            _connection = (SqlConnection)connection;
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
            _isPrivateConnection = false;
        }
        #endregion

        /// <summary>
        /// Libera los recursos asociados al objeto
        /// </summary>
        public void Dispose()
        {
            if (_isPrivateConnection
                && _connection != null
                && _connection.State != ConnectionState.Closed)
            {
                _connection.Dispose();
            }
        }

        /// <summary>
        /// Devuelve el connectionString necesario para conectarse a la BBDD
        /// </summary>
        private static string CrearConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "LAPTOP-56O65CF8\\SQLEXPRESS";
            builder.InitialCatalog = "master";
            builder.UserID = "sa";
            builder.Password = "Godofwar1531";
            builder.ApplicationName = "MyApp";
            return builder.ConnectionString;
        }

        /// <summary>
        /// Crea la conexión a la BBDD y la devuelve
        /// </summary>
        public static IDbConnection CrearConexion()
        {
            var connectionString = CrearConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return connection;
                }
                catch (Exception ex)
                {
                    return new SqlConnection();
                }
            }
        }

        /// <summary>
        /// Devuelve la conexión que está siendo utilizada por el objeto
        /// </summary>
        protected SqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }
    }
}
