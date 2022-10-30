using System.Data;
using System.Data.SqlClient;

namespace Pinewood.DMSSample.Business.DbContext.DbComponents
{
    internal static class SqlCmd
    {
        internal static SqlCommand Build(SqlConnection connection, string sql, CommandType @type)
        {
            var cmd = new SqlCommand(sql, connection);
            cmd.CommandType = @type;

            return cmd;
        }
    }
}
