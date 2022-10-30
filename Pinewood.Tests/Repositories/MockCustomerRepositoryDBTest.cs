using Pinewood.DMSSample.Business;
using Pinewood.DMSSample.Business.Repositories;
using Pinewood.DMSSample.Business.Repositories.CustomerRepositories;

namespace Pinewood.Tests
{
    public class MockCustomerRepositoryDBTest
    {
        [Fact]
        public async Task TestCustomerRepo_GetByName_ShouldNotBeNull()
        {
            IQueryRepo<Customer> queryRepo = new MockCustomerRepositoryDB();

            var result = await queryRepo.GetByName("John Doe");

            Assert.True(result != null);
            Assert.IsType<Customer>(result);
        }

        [Fact]
        public async Task TestCustomerRepo_GetByName_GetExactMatchByName()
        {
            IQueryRepo<Customer> queryRepo = new MockCustomerRepositoryDB();

            var customerName = "John Doe";
            var result = await queryRepo.GetByName(customerName);

            Assert.True(result?.Name.Equals(customerName));
        }
    }
}