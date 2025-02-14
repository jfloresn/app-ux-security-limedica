

using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using app_ux_security_limedica.Model;
using Microsoft.Data.SqlClient;

namespace app_ux_security_limedica.Infraestructure
{
    public class UsuarioRepository
    {

        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async IAsyncEnumerable<Usuario> ObtenerUsuariosAsync()
        {

            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync(); 



            var command = new CommandDefinition(
                "SELECT usr_int_id AS Id, usr_str_nombre AS Nombre FROM [seguridad].[tbl_usuario]",
                cancellationToken: default
            );

            var reader = await connection.ExecuteReaderAsync(command);

            while (await reader.ReadAsync())
            {
                yield return new Usuario
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1)
                };
            }
        }


    }

  
}
