using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProducts.Models;

namespace WebApiProducts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController
    {
        // GET: api/<DriverController>
        [HttpGet]
        public ApiResponse Get()
        {
            return new ProductModel().GetAll();
        }

        /*
        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DriverController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
