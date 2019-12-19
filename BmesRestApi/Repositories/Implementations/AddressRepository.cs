namespace BmesRestApi.Repositories.Implementations
{
    using Database;
    using Models.Address;
    using System.Collections.Generic;

    public class AddressRepository : IAddressRepository
    {

        private BmesDbContext _context;

        public AddressRepository(BmesDbContext context)
        {
            _context = context;
        }

        public Address FindAddressById(long id)
        {
            var address = _context.Addresses.Find(id);
            return address;
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            var addresses = _context.Addresses;
            return addresses;
        }

        public void SaveAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
        }

        public void DeleteAddress(Address address)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }
    }
}
