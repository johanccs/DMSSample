using Pinewood.DMSSample.Business.DbContext;
using System.Data;
using System.Data.SqlClient;

namespace Pinewood.DMSSample.Business.Repositories.CustomerRepositories
{
    public class CustomerRepositoryDB : IQueryRepo<Customer>
    {
        public async Task<Customer?> GetByName(string name)
        {
            var reader = await SqlContext.QueryAsync("CRM_GetCustomer", CommandType.StoredProcedure, name);

            return BuildCustomer(reader);
        }

        private Customer? BuildCustomer(SqlDataReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader), "Invalid sql data reader");

            while (reader.Read())
            {
                return new Customer(
                    id: (int)reader["CustomerID"],
                    name: (string)reader["Name"],
                    address: (string)reader["Address"]
                );
            }

            return null;
        }
    }
}
