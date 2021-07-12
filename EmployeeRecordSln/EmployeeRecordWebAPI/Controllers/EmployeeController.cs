using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EmployeeRecordWebAPI.Models;

namespace EmployeeRecordWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        //Create Employee Records Entities Object
        private EmployeeRecordsEntities db = new EmployeeRecordsEntities();

        // GET: api/Employee
        //Using this method Return List Of All Employee
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;//Return All Employee
        }

        // GET: api/Employee/5
        [ResponseType(typeof(Employee))]
        //Using this method Return Specific Employee By Id
        public IHttpActionResult GetEmployee(int id) //id=Employee Id
        {
            Employee employee = db.Employees.Find(id);//Get Specific Employee from Employees Entity
            if (employee == null)//If employee result is null 
            {
                return NotFound();//If null then return not found
            }

            return Ok(employee);//If record found then return employee
        }

        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        //Using this method update Specific Employee Record
        public IHttpActionResult PutEmployee(int id, Employee employee) //id=Employee Id,employee=Employee Object
        { 
            if (id != employee.Id)//Check Id And Employee Is equal
            {
                return BadRequest(); //If not equal then send bad request
            }

            db.Entry(employee).State = EntityState.Modified;//Update employee state to modified

            try
            {
                db.SaveChanges();//Save change employee entity
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))//Using EmployeeExists Method Check Employee Exists on EmployeeEntity
                {
                    return NotFound();//If Not exists then return not found
                }
                else
                {
                    throw; //throw exception
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employee
        [ResponseType(typeof(Employee))]
        //Using this method Save Employee Record to Database
        public IHttpActionResult PostEmployee(Employee employee)
        {
             

            db.Employees.Add(employee);//Add employee object to Employee Entity
            db.SaveChanges();//Save change employee entity

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employee/5
        [ResponseType(typeof(Employee))]
        //Using this method Delete specific Employee record from database
        public IHttpActionResult DeleteEmployee(int id)//id=Employee Id
        {
            Employee employee = db.Employees.Find(id);//Find specific employee form Employee Entity using Employee Id
            if (employee == null)//If employee result is null 
            {
                return NotFound();//If Not exists then return not found
            }

            db.Employees.Remove(employee);//Remove employee from employee entity
            db.SaveChanges();//Save change employee entity

            return Ok(employee);//Return ok
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //Using this method check employee exists on the database
        private bool EmployeeExists(int id)//id=Employee Id
        {
            return db.Employees.Count(e => e.Id == id) > 0;//count employee exist on employee entity using employee id
        }
    }
}