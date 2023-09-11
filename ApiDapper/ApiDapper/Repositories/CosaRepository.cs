using ApiDapper.Entities;
using ApiDapper.Interfaces.Repositories;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using static Dapper.SqlMapper;

namespace ApiDapper.Repositories
{
    public class CosaRepository : ICosaRepository
    {
        private readonly string _connectionString;
        public CosaRepository(IConfiguration configuration) {
            this._connectionString = configuration.GetConnectionString("ApiDapperDB");
        }
        public async Task<int> DeleteById(int id)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = $"Delete from cosas " +
                $"where id=${id}";

                var result = await conn.ExecuteAsync(query);

                return result;
            }

        }

        public async Task<IEnumerable<Cosa>> GetAll()
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var result = await conn.QueryAsync<Cosa>("select * from Cosas");

                return result;
            }
        }

        public async Task<Cosa?> GetById(int id)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var result = await conn.QueryFirstOrDefaultAsync<Cosa>($"select * from Cosas where id = {id}");

                return result;
            }
        }

        public async Task<int> Insert(Cosa entity)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = $"insert into Cosas(nombre, descripcion) " +
                    $"values('{entity.Nombre}', '{entity.Descripcion}')";

                var result = await conn.ExecuteAsync(query);

                return result;
            }
        }

        public async Task<int> Update(int id, Cosa entity)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = $"Update Cosas set nombre='{entity.Nombre}', descripcion ='{entity.Descripcion}' " +
                    $"where id=${id}";

                var result = await conn.ExecuteAsync(query);

                return result;
            }
        }
    }
}
