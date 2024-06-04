using Microsoft.EntityFrameworkCore.Infrastructure;
using ModelLayer;
using RepoLayer.CustomException;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CustomerBL : ICustomerBL
    {
        private readonly ICustomerRL customerRL;

        public CustomerBL(ICustomerRL customerRL)
        {
            this.customerRL = customerRL;
        }
        public Customer AddCustomer(CustomerModel customer)
        {
            try
            {
                string phonepattern = @"\b((\d{0,3})\s)?\d{6,10}\b";
                Regex regexphone = new Regex(phonepattern);
                string emailpattern = @"\b\w+\.?\w+?\@[a-z]+\.[a-z]+((?:.)[a-z]{1,})*";
                Regex regexemail = new Regex(emailpattern);

                if (regexemail.IsMatch(customer.email) && regexphone.IsMatch(customer.phone))
                {
                    return customerRL.AddCustomer(customer);
                }
                else
                {
                    throw new NotValidDetailsException("Please enter Email or phone in correct format");
                }
            }
            catch(NotValidDetailsException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void DeleteCustomer(int id)
        {
            customerRL.DeleteCustomer(id);
        }

        public List<Customer> GetAll()
        {
            return customerRL.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return customerRL.GetCustomer(id);
        }

        public Customer UpdateCustomer(int id, CustomerModel c)
        {
            string phonepattern = @"\b((\d{0,3})\s)?\d{6,10}\b";
            Regex regexphone = new Regex(phonepattern);
            string emailpattern = @"\b\w+\.?\w+?\@[a-z]+\.[a-z]+((?:.)[a-z]{1,})*";
            Regex regexemail = new Regex(emailpattern);

            if (regexemail.IsMatch(c.email) && regexphone.IsMatch(c.phone))
            {
                return customerRL.UpdateCustomer(id, c);
            }
            else
            {
                throw new NotValidDetailsException("Please enter Email or phone in correct format");
            }
            
        }
    }
}
