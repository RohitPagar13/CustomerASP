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

                    if (!regexemail.IsMatch(customer.email) && !regexphone.IsMatch(customer.phone))
                    {
                        throw new NotValidDetailsException("Please enter Email or phone in correct format");
                    }
                    return customerRL.AddCustomer(customer);
                }
                catch(NotValidDetailsException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    throw;
                }
            }

        public void DeleteCustomer(int id)
        {
            try
            {
                customerRL.DeleteCustomer(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                return customerRL.GetAll();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                return customerRL.GetCustomer(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public Customer UpdateCustomer(int id, CustomerModel c)
        {
            try
            {
                string phonepattern = @"\b((\d{0,3})\s)?\d{6,10}\b";
                Regex regexphone = new Regex(phonepattern);
                string emailpattern = @"\b\w+\.?\w+?\@[a-z]+\.[a-z]+((?:.)[a-z]{1,})*";
                Regex regexemail = new Regex(emailpattern);

                if (!regexemail.IsMatch(c.email) && !regexphone.IsMatch(c.phone))
                {
                    throw new NotValidDetailsException("Please enter Email or phone in correct format");
                }
                return customerRL.UpdateCustomer(id, c);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}
