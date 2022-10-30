using Pinewood.DMSSample.Business.Dtos;

namespace Pinewood.DMSSample.Business.ExternalRepoHelpers
{
    internal static class ExternalRepo
    {
        internal static async Task<PartAvailabilityDto> GetPartAvailability(string stockCode)
        {
            using (PartAvailabilityClient _PartAvailabilityService = new PartAvailabilityClient())
            {
                int availability = await _PartAvailabilityService.GetAvailability(stockCode);

                if (availability <= 0)
                {
                    return new PartAvailabilityDto(new CreatePartInvoiceResult(false));
                }

                return new PartAvailabilityDto(availability);
            }
        }
    }
}
