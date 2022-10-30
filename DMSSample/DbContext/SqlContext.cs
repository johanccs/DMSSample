using Pinewood.DMSSample.Business.DbContext.DbComponents;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Pinewood.DMSSample.Business.DbContext
{
    internal class SqlContext
    {
        private static readonly string _connectionString;

        static SqlContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["appDatabase"].ConnectionString;
        }

        internal static async Task<SqlDataReader> QueryAsync(string query, CommandType type, params string[] paramnames)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand _command = SqlCmd.Build(_connection, query, type);

                foreach (var param in paramnames)
                {
                    SqlParameter parameter = Param.Build($"@{nameof(param)}", param);

                    _command.Parameters.Add(parameter);
                }

                SqlDataReader _reader = await _command.ExecuteReaderAsync(CommandBehavior.CloseConnection);

                return _reader;
            }
        }

        internal static async Task<bool> CommandAsync(string commandText, CommandType type, List<SqlParameter> parms)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand _command = SqlCmd.Build(_connection, commandText, type);

                foreach (var param in parms)
                {
                    _command.Parameters.Add(param);
                }

                var result = await _command.ExecuteNonQueryAsync();

                return result > 0;
            }
        }

        internal static async Task<bool> CommandAsync(string commandText, CommandType type, Func<IEnumerable<SqlParameter>> parms)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlCommand _command = SqlCmd.Build(_connection, commandText, type);
                var paramList = parms();

                foreach (var param in paramList)
                {
                    _command.Parameters.Add(param);
                }

                var result = await _command.ExecuteNonQueryAsync();

                return result > 0;
            }
        }
    }
}