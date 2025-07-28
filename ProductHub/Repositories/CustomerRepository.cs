using YourNamespace.Models;

namespace YourNamespace.Repositories
{
    public class CustomerRepository
    {
        private static List<Customer> customers = new List<Customer>();
        private static long idCounter = 1;

        public IEnumerable<Customer> GetAll() => customers;

        public Customer? GetById(long id) => customers.FirstOrDefault(c => c.Id == id);

        public Customer Add(Customer c)
        {
            c.Id = idCounter++;
            customers.Add(c);
            return c;
        }

        public bool Update(long id, Customer updated)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.Name = updated.Name;
            existing.Email = updated.Email;
            existing.Phone = updated.Phone;
            return true;
        }

        public bool Delete(long id)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            customers.Remove(existing);
            return true;
        }
    }
}
