namespace Pinewood.DMSSample.Business.Base
{
    public abstract class BaseController
    {
        protected virtual CreatePartInvoiceResult Validate(string stockCode, int quantity, string customerName)
        {
            if (string.IsNullOrEmpty(stockCode))
            {
                return new CreatePartInvoiceResult(false);
            }

            if (quantity <= 0)
            {
                return new CreatePartInvoiceResult(false);
            }

            return new CreatePartInvoiceResult(true);
        }
    }
}
