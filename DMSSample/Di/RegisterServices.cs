using Microsoft.Extensions.DependencyInjection;
using Pinewood.DMSSample.Business.DbContext.DbComponents;
using Pinewood.DMSSample.Business.Repositories;
using Pinewood.DMSSample.Business.Repositories.CustomerRepositories;
using Pinewood.DMSSample.Business.Repositories.InvoiceRepositories;

namespace Pinewood.DMSSample.Business.Di
{
    public static class RegisterServices
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddScoped<ICommandRepo<PartInvoice>, PartInvoiceRepositoryDB>();

            services.AddScoped<IQueryRepo<Customer>, CustomerRepositoryDB>();

            return services;
        }
    }
}
