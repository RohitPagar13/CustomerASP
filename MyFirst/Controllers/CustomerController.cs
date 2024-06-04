using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace MyFirst.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBL customerBL;

        public CustomerController(ICustomerBL customerBL)
        {
            this.customerBL = customerBL;
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerModel customerModel)
        {
            var result = customerBL.AddCustomer(customerModel);

            if(result != null)
            {
                return Created("Created successfully",result);
            }
            else
            {
                return BadRequest("Enter Valid data!!");
            }
        }

        [HttpGet]
        [Route("api/Customers/id")]
        public IActionResult GetCustomer(int id)
        {
            var result = customerBL.GetCustomer(id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Enter valid id!!");
            }
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var result = customerBL.GetAll();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Some Error occurred!!");
            }
        }

        [HttpPut]
        public IActionResult UpdateCustomer(int id, CustomerModel model)
        {
            var result = customerBL.UpdateCustomer(id, model);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Enter valid id!!");
            }
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            try {
                customerBL.DeleteCustomer(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Id not found");
            }
        }
    }
}
