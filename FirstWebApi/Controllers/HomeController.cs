using FirstWebApi.Models;
using FirstWebApi.Models.Custom_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FirstWebApi.Controllers
{
    public class HomeController : Controller
    {
        HttpClient ApiData = new HttpClient();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult TableData()
        {
            try
            {
                List<ApiTable> TableData = new List<ApiTable>();
                ApiData.BaseAddress = new Uri("http://localhost:49879/api/ConsumeData");
                var Response = ApiData.GetAsync("ConsumeData");
                Response.Wait();
                var Result = Response.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var DisplayTable = Result.Content.ReadAsAsync<List<ApiTable>>();
                    DisplayTable.Wait();
                    TableData = DisplayTable.Result;
                }
                return View(TableData);

            }
            catch(Exception E)
            {
                throw E;
            }
        }

        public ActionResult AddStudent()
        {
            try
            {
                return View();
            }
            catch(Exception E)
            {
                throw E;
            }
        }

        [HttpPost]
        public ActionResult AddStudent(EmployeeModel Empdata)
        {
            try
            {
                List<ApiTable> MainTable = new List<ApiTable>();
                ApiData.BaseAddress = new Uri("http://localhost:49879/api/ConsumeData");
                var Response = ApiData.PostAsJsonAsync("ConsumeData", Empdata);
                Response.Wait();
                var Test = Response.Result;
                if (Test.IsSuccessStatusCode)
                {
                return RedirectToAction("TableData");
                }
                return RedirectToAction("AddStudent");
            }
            catch(Exception E)
            {
                throw E;
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                EmployeeModel MainTable = null;
                ApiData.BaseAddress = new Uri("http://localhost:49879/api/ConsumeData");
                var Response = ApiData.GetAsync("ConsumeData?id=" + id.ToString());
                Response.Wait();
                var Test = Response.Result;
                if (Test.IsSuccessStatusCode)
                {
                    var DisplayTable = Test.Content.ReadAsAsync<EmployeeModel>();
                    DisplayTable.Wait();
                    MainTable = DisplayTable.Result;
                }
                return RedirectToAction("AddStudent");
            }
            catch (Exception E)
            {
                throw E;
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                EmployeeModel MainTable = null;
                ApiData.BaseAddress = new Uri("http://localhost:49879/api/ConsumeData");
                var Response = ApiData.GetAsync("ConsumeData?id=" + id.ToString());
                Response.Wait();
                var Test = Response.Result;
                if (Test.IsSuccessStatusCode)
                {
                    var DisplayData = Test.Content.ReadAsAsync<EmployeeModel>();
                    DisplayData.Wait();
                    MainTable = DisplayData.Result;
                }
                return View(MainTable);
            }
            catch(Exception E)
            {
                throw E;
            }
        }

        [HttpPost ,ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try {
                ApiData.BaseAddress = new Uri("http://localhost:49879/api/ConsumeData");
                var Response = ApiData.DeleteAsync("ConsumeData/" + id.ToString());
                Response.Wait();
                var Test = Response.Result;
                if (Test.IsSuccessStatusCode)
                {
                    return RedirectToAction("TableData");
                }
                return View("TableData");

            }
            catch(Exception E)
            {
                throw E;
            }
        }
    }
}
