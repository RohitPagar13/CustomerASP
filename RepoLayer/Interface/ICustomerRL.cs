using ModelLayer;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface
{
    public interface ICustomerRL
    {
        public Customer AddCustomer(CustomerModel c);

        public Customer UpdateCustomer(int id,CustomerModel c);

        public void DeleteCustomer(int id);

        public Customer GetCustomer(int id);

        public List<Customer> GetAll();
    }
}
