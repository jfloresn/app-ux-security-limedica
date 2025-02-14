using app_ux_security_limedica.Infraestructure.repository;
using app_ux_security_limedica.Model;
using System.Data;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace app_ux_security_limedica.Infraestructure.filtro
{
    public class FiltrarEspecialidadEditorialRepository
    {

        private readonly DatabaseConnectionService _dbConnectionService;

        // Inyección de dependencias para acceder al servicio de conexión
        public FiltrarEspecialidadEditorialRepository(DatabaseConnectionService dbConnectionService)
        {
            _dbConnectionService = dbConnectionService;
        }

        public async Task<IEnumerable<BookFiltroDTO>> ObtenerLibrosAsync(
            int opcion,
            int? idEditorial = null,
            int? idEspecialidad = null)
        {
            var connection = _dbConnectionService.GetConnection();
            await connection.OpenAsync(); // Solo abrir la conexión una vez.

            var parametros = new
            {
                opcion,
                idEditorial,
                idEspecialidad
            };

            return await connection.QueryAsync<BookFiltroDTO>(
                "[ecommerce].[usp_book_filtro]",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
