using Crud_Ajax_Api.DataBase;
using Crud_Ajax_Api.EntityModel;
using Microsoft.AspNetCore.Mvc;
using SampleCommerce.API.ApiModel.Customer;
using System.Text.Json.Nodes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleCommerce.API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public DbContext_Crud _db;

        public CustomerController(DbContext_Crud customerService)
        {
            _db = customerService;
        }



        // GET: api/<CustomerController>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var customers = _db.Customers.ToList();
        //    if (customers.Any())
        //    {
        //        return Ok(customers);
                
        //    }
        //    return NotFound();
        //}

        [HttpGet]
        public IEnumerable<Customer> GetEmployees()
        {
            return _db.Customers.ToList().AsEnumerable();
              
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           var customer = _db.Customers.FirstOrDefault(c=>c.Id==id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);

        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult  Post([FromForm] CustomerCreateDTO model)
        {
            var customer = new Customer()
            {
                Name= model.Name,
                Code = model.Code,
                Phone = model.Phone,
                Address = model.Address
            };

            _db.Customers.Add(customer);
             var result  =_db.SaveChanges();

            if(result>0)
            {
                return Ok(result);
            }
            return BadRequest();
            
            
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var existingCustomer = _db.Customers.FirstOrDefault(c=>c.Id==id);

                existingCustomer.Name = model.Name;
                existingCustomer.Code = model.Code;
                existingCustomer.Address = model.Address;
                existingCustomer.Phone = model.Phone;
             

              _db.Customers.Update(existingCustomer);

                var result = _db.SaveChanges();
                if (result > 0)
                {
                    return Ok(existingCustomer);
                }
                 
                
                

            }
            return BadRequest();

        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _db.Customers.FirstOrDefault(c=>c.Id==id);

             _db.Customers.Remove(customer);

            var result = _db.SaveChanges();
            
            if(result>0) 
            { 
                return Ok(); 
            }
                return BadRequest();
            
            
        }
    }
}
