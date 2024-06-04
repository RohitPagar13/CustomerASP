using ModelLayer;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoLayer.Context;
using RepoLayer.CustomException;
using System.Text.RegularExpressions;
using Microsoft.Identity.Client;

namespace RepoLayer.Service
{
    public class CustomerRL:ICustomerRL
    {
        private readonly Mydb _db;

        public CustomerRL(Mydb db)
        {
            this._db = db;
        }

        public Customer AddCustomer(CustomerModel c)
        {
            try
            {
                if (_db.customers.Any(customer => customer.email.Equals(c.email) && customer.phone.Equals(c.phone)))
                {
                    throw new CustomerAlreadyExists("Customer with specified Email or Phone Already Exists");
                }
                Customer customer = new Customer();

                customer.FName = c.FName;

                customer.LName = c.LName;

                customer.email = c.email;

                customer.phone = c.phone;

                _db.customers.Add(customer);
                _db.SaveChanges();
                return customer;
            }
            catch(CustomerAlreadyExists ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public void DeleteCustomer(int id)
        {
            Customer? c = _db.customers.Find(id);
            try
            {
                if (c == null)
                {
                    throw new CustomerNotFoundException("Customer with the specified ID does not exist.");
                }
                _db.customers.Remove(c);
                _db.SaveChanges();
            }
            catch(CustomerNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                return _db.customers.ToList<Customer>();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                Customer? c = _db.customers.Find(id);
                if (c == null)
                {
                    throw new CustomerNotFoundException("Customer with the specified ID does not exist.");
                }
                return c;
            }
            catch (CustomerNotFoundException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public Customer UpdateCustomer(int id, CustomerModel cm)
        {
            try
            {
                Customer? c= _db.customers.Find(id);
                if (c == null)
                {
                    throw new CustomerNotFoundException("Customer with the specified ID does not exist.");
                }
                c.FName = cm.FName;
                c.LName = cm.LName;
                c.email = cm.email;
                c.phone = cm.phone;
                _db.customers.Update(c);
                _db.SaveChanges();
                return c;
            }
            catch(CustomerNotFoundException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
