// See https://aka.ms/new-console-template for more information
using Pinewood.DMSSample.Business;
using Microsoft.Extensions.DependencyInjection;
using Pinewood.DMSSample.Business.Di;

var services = ConfigureServices(new ServiceCollection());

DMSClient dmsClient = new DMSClient();

await dmsClient.CreatePartInvoiceAsync("1234", 10, "John Doe");


static IServiceCollection ConfigureServices(IServiceCollection services)
{
    return RegisterServices.Register(services);
}
