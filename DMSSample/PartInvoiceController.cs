using Pinewood.DMSSample.Business.Base;
using Pinewood.DMSSample.Business.ExternalRepoHelpers;
using Pinewood.DMSSample.Business.Repositories;

namespace Pinewood.DMSSample.Business
{
    public class PartInvoiceController: BaseController
    {
        #region Readonly Fields

        private readonly IQueryRepo<Customer> _queryRepo;

        private readonly ICommandRepo<PartInvoice> _commandRepo;

        #endregion

        #region Fields

        bool opResult = false;

        #endregion

        #region Ctor

        public PartInvoiceController()
        {
            //Empty constructor to satisfy SampleConsole project.
        }

        public PartInvoiceController(IQueryRepo<Customer>queryRepo, ICommandRepo<PartInvoice>commandRepo)
        {
            _queryRepo = queryRepo;
            _commandRepo = commandRepo;
        }

        #endregion

        #region Public Methods

        public async Task<CreatePartInvoiceResult> CreatePartInvoiceAsync(string stockCode, int quantity, string customerName)
        {

            if (!Validate(stockCode, quantity, customerName).Success)
                throw new ArgumentException("Input values invalid");

            try
            {
                var customer = await _queryRepo.GetByName(customerName);

                int custID = customer?.ID ?? 0;
                if (custID <= 0)
                {
                    return new CreatePartInvoiceResult(false);
                }

                var result = await ExternalRepo.GetPartAvailability(stockCode);

                if (result.ResultCount < 0)
                    return result.ExecptionResult;

                PartInvoice partInvoice = new PartInvoice(
                    stockCode: stockCode,
                    quantity: quantity,
                    customerID: custID
                );

                await _commandRepo.Add(partInvoice);

                opResult = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new CreatePartInvoiceResult(opResult);
        }

        #endregion

    }
}
