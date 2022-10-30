namespace Pinewood.DMSSample.Business.Dtos
{
    internal sealed class PartAvailabilityDto
    {
        public PartAvailabilityDto(int resultCount)
        {
            if (resultCount < 0)
                throw new ArgumentNullException(nameof(resultCount), "Invalid result count");

            ResultCount = resultCount;
            ExecptionResult = new CreatePartInvoiceResult(true);
        }

        public PartAvailabilityDto(CreatePartInvoiceResult execptionResult)
        {
            ExecptionResult = execptionResult;
            ExecptionResult = new CreatePartInvoiceResult(false);
        }

        public CreatePartInvoiceResult ExecptionResult { get; private set; }
        public int ResultCount { get; private set; } = -1;
       
    }
}
