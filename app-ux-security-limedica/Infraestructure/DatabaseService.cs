

using System.Data;
using Microsoft.Data.SqlClient; // Importa la versión correcta
using Dapper;


namespace app_ux_security_limedica.Infraestructure
{
    public class DatabaseService
    {

        private readonly string _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        private IDbConnection CreateConnection() => new SqlConnection(_connectionString); // Ahora sí reconocerá SqlConnection


        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<Usuario>("select usr_int_id as Id, usr_str_nombre as Nombre from [seguridad].[tbl_usuario]");
        }

   
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}
