namespace Pinewood.DMSSample.Business.Repositories.InvoiceRepositories
{
    public class MockInvoiceRepositoryDB : ICommandRepo<PartInvoice>
    {
        #region Private Fields

        private IList<PartInvoice> _invoices;

        #endregion

        #region Ctor

        public MockInvoiceRepositoryDB()
        {
            _invoices = new List<PartInvoice>();
        }

        #endregion

        public async Task Add(PartInvoice entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Invalid Part Invoice");

            await Task.Run(() =>
            {
                _invoices.Add(entity);
            });
        }
    }
}
