using FirstWebApi.Models;
using FirstWebApi.Models.Custom_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebApi.Controllers
{
    public class ConsumeDataController : ApiController
    {
        Manav_SchoolMgmt_42Entities Context = new Manav_SchoolMgmt_42Entities();

        [HttpGet]
        public IHttpActionResult GetStudent()
        {
            try
            {
            List <ApiTable> data = Context.ApiTables.ToList();
            return Ok(data);
            }
            catch(Exception E)
            {
                throw E;
            }
        }

        [HttpPost]
        public IHttpActionResult PostStudent(EmployeeModel EmpData)
        {
            try
            {
                ApiTable Data = new ApiTable { 
                    Name = EmpData.Name,
                    Email = EmpData.Email,
                    PhoneNumber = EmpData.PhoneNumber,
                    CountryName = EmpData.CountryName
                
                };
                Context.ApiTables.Add(Data);
                Context.SaveChanges();
                return Ok();
            }
            catch(Exception E)
            {
                throw E;
            }
        }

        [HttpGet]
        public IHttpActionResult GetStudentById(int id)
        {
            try
            {
                var Student = Context.ApiTables.Where(x => x.Id == id).FirstOrDefault();
                return Ok(Student);
            }
            catch(Exception E)
            {
                throw E;
            }
        }

        [HttpDelete]
        public IHttpActionResult DelStudent(int id)
        {
            try
            {
                var Student = Context.ApiTables.Where(z => z.Id == id).FirstOrDefault();
                Context.ApiTables.Remove(Student);
                Context.SaveChanges();
                return Ok();
            }
            catch(Exception E)
            {
                throw E;
            }
        }

        [HttpPut]
        public IHttpActionResult EditStudent(ApiTable Emp)
        {
            try
            {
                var Student = Context.ApiTables.Where(x => x.Id == Emp.Id).FirstOrDefault();
                if (Student != null)
                {
                    Student.Id = Emp.Id;
                    Student.Name = Emp.Name;
                    Student.Email = Emp.Email;
                    Student.PhoneNumber = Emp.PhoneNumber;
                    Student.CountryName = Emp.CountryName;
                    Context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception E)
            {
                throw E;
            }
        }

    }
}
