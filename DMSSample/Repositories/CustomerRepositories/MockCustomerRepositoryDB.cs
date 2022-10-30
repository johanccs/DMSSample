namespace Pinewood.DMSSample.Business.Repositories.CustomerRepositories
{
    public class MockCustomerRepositoryDB : IQueryRepo<Customer>
    {
        #region Readonly Fields

        private readonly IEnumerable<Customer> _customers;

        #endregion

        #region Ctor

        public MockCustomerRepositoryDB()
        {
            _customers = new List<Customer>
            {
                new Customer(1, "John Doe", "10 Church Street, London"),
                new Customer(1, "John Doe1", "Connor Road, London"),
                new Customer(1, "John Doe2", "Lockwell Road, London"),
                new Customer(1, "John Doe3", "10th Ave, New York"),
                new Customer(1, "John Doe4", "6th Ave, New York")
            };
        }

        #endregion

        #region Public Methods

        public Task<Customer?> GetByName(string name)
        {
            if (_customers.Any())
                return Task.FromResult(_customers.FirstOrDefault(x => x.Name.Equals(name)));

            return Task.FromResult<Customer?>(null);
        }

        #endregion
    }
}
