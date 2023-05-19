using FirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebApi.Controllers
{
    public class FirstApiController : ApiController
    {
        public string[] Data = { "Manav", "Yash", "Rushik", "Jay" };
        Manav_SchoolMgmt_42Entities Context = new Manav_SchoolMgmt_42Entities();

        // Getting All Data Of an Api
        [HttpGet]
        public string[] GetData()
        {
            return (Data);
        }

        // // Getting Api Values Using Parameters
        [HttpGet]
        public string GetDataByIndex(int id)
        {
            return (Data[id]);
        }

        //Always Add Prefixes What does that Method Does.

        // Let Fetch Database values Using Entity Framework


        //[HttpGet]
        // public IHttpActionResult GetStudent()
        // {
        //     List<StudentDetail> Data = Context.StudentDetails.ToList();
        //     return Ok(Data);
        // }

        // // Fetching Data By specified value
        // [HttpGet]
        // public IHttpActionResult GetStudentById (int id)
        // {
        //     var data = Context.StudentDetails.Where(x => x.Id == id);
        //     return Ok(data);
        // }
    }
}
