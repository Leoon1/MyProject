using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyProject.DAL.Context;
using MyProject.Domain.Models;

namespace MyProject.ServiceHosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly MyProjectDB _myProjectDb;
        public EmployeesController(MyProjectDB myProjectDb)
        {
            _myProjectDb = myProjectDb;
        }

        //private static readonly List<string> __Values = Enumerable
        //    .Range(1, 10)
        //    .Select(i => $"Value{i:00}")
        //    .ToList();

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _myProjectDb.Employees.ToList();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //if (id < 0)
            //    return BadRequest();
            //if (id >= __Values.Count)
            //    return NotFound();

            return BadRequest() /*__Values[id]*/;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            //__Values.Add(value);
            return BadRequest();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            //if (id < 0)
            //    return BadRequest();
            //if (id >= __Values.Count)
            //    return NotFound();

            //__Values[id] = value;
            return BadRequest();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //if (id < 0)
            //    return BadRequest();
            //if (id >= __Values.Count)
            //    return NotFound();

            //__Values.RemoveAt(id);

            return BadRequest();
        }
    }
}
