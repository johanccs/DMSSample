using System.Data;
using System.Data.SqlClient;

namespace Pinewood.DMSSample.Business.DbContext.DbComponents
{
    internal static class Param
    {
        internal static SqlParameter Build<T>(string name, T val)
            => new SqlParameter(name, val);

        internal static SqlParameter Build<T>(string name, SqlDbType type, int size, T val)
        {
            var param = new SqlParameter(name, type, size);
            param.Value = val;

            return param;
        }

        internal static SqlParameter Build<T>(string name, SqlDbType type, T val)
        {
            var param = new SqlParameter(name, type);
            param.Value = val;

            return param;
        }
    }
}
