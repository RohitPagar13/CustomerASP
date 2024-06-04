using ModelLayer;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ICustomerBL
    {
        public Customer AddCustomer(CustomerModel customer);

        public Customer UpdateCustomer(int id, CustomerModel c);

        public void DeleteCustomer(int id);

        public Customer GetCustomer(int id);

        public List<Customer> GetAll();
    }
}
