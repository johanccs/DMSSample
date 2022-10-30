using Pinewood.DMSSample.Business.DbContext;
using Pinewood.DMSSample.Business.DbContext.DbComponents;
using System.Data;
using System.Data.SqlClient;

namespace Pinewood.DMSSample.Business.Repositories.InvoiceRepositories
{
    public class PartInvoiceRepositoryDB : ICommandRepo<PartInvoice>
    {
        public async Task Add(PartInvoice invoice)
        {
            var result = await SqlContext.CommandAsync(
                "PMS_AddPartInvoice", CommandType.StoredProcedure, () =>
                 {
                     IList<SqlParameter> parms = new List<SqlParameter>
                    {
                            Param.Build("@StockCode", SqlDbType.VarChar,50,invoice.StockCode),
                            Param.Build("@Quantity", SqlDbType.Int, invoice.Quantity),
                            Param.Build("@@CustomerID", SqlDbType.Int, invoice.CustomerID),
                    };

                     return parms;
                 });
        }
    }
}
