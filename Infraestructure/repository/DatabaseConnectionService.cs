using Microsoft.Data.SqlClient;
using System.Data;

namespace app_ux_security_limedica.Infraestructure.repository
{
    public class DatabaseConnectionService
    {
        private readonly string _connectionString;

        // Constructor que obtiene la cadena de conexión desde la configuración.
        public DatabaseConnectionService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Método para obtener una conexión a la base de datos.
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString); // Retorna una nueva conexión
        }
    }
}
