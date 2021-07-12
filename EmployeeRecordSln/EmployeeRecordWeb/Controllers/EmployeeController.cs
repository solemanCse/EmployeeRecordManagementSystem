using EmployeeRecordWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace EmployeeRecordWeb.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllEmployee()
        {

            try
            {

                HttpClient webApiClient = new HttpClient();//Consume Web Api Using HttpClient
                webApiClient.BaseAddress = new Uri("https://localhost:44342/api/");//We have to pass base address for the wep api project
                webApiClient.DefaultRequestHeaders.Clear();//Clear Defalt Request Header
                webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//Set media type as JSON
                HttpResponseMessage msg = webApiClient.GetAsync("Employee").Result;//Set Rest Url Of Web Api to Get All Employee Record
                var result = msg.Content.ReadAsAsync<IEnumerable<EmployeeModel>>().Result;//Read Message Content and Convert to IEnumerable Employee List
                //return Json(new { success = true, Data = result }, JsonRequestBehavior.AllowGet);// Return  As JSON Result
                J
                 return Json(new { success = true, Data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, data = ex.Message }, JsonRequestBehavior.AllowGet);// Return  As JSON Result
            }
        }

        public JsonResult GetSpecificEmployee(int Id)
        {

            try
            {

                HttpClient webApiClient = new HttpClient();//Consume Web Api Using HttpClient
                webApiClient.BaseAddress = new Uri("https://localhost:44342/api/");//We have to pass base address for the wep api project
                webApiClient.DefaultRequestHeaders.Clear();//Clear Defalt Request Header
                webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//Set media type as JSON
                HttpResponseMessage msg = webApiClient.GetAsync("Employee/" + Id).Result;//Set Rest Url Of Web Api to Get Specific Employee Record
                var result = msg.Content.ReadAsAsync<EmployeeModel>().Result;//Read Message Content and Convert to  Employee Object
                return Json(new { success = true, Data = result }, JsonRequestBehavior.AllowGet);// Return  As JSON Result
            }
            catch (Exception ex)
            {

                return Json(new { success = false, data = ex.Message }, JsonRequestBehavior.AllowGet);// Return  As JSON Result
            }
        }

        public JsonResult SaveOrUpdateEmployee(EmployeeModel emp)
        {

            try
            {

                HttpClient webApiClient = new HttpClient();//Consume Web Api Using HttpClient
                webApiClient.BaseAddress = new Uri("https://localhost:44342/api/");//We have to pass base address for the wep api project
                webApiClient.DefaultRequestHeaders.Clear();//Clear Defalt Request Header
                webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//Set media type as JSON
                var result = "";//Declare a veriable to store outpot message for insert or update
                if (emp.Id == 0)//If Employee Id Is zero then go for insert
                {
                    HttpResponseMessage msg = webApiClient.PostAsJsonAsync("Employee", emp).Result;//Set Rest Url Of Web Api to Save the Employee Record
                    result = "Record save Successfully !!!";//to Set Message after save is done
                }
                else //If Employee Id Is not zero then go for update
                {
                    HttpResponseMessage msg = webApiClient.PutAsJsonAsync("Employee/" + emp.Id, emp).Result;//Set Rest Url Of Web Api to Update the Employee Record
                    result = "Record update Successfully !!!";//to Set Message after update is done
                }
                return Json(new { success = true, Data = result }, JsonRequestBehavior.AllowGet);// Return  As JSON Result
            }
            catch (Exception ex)
            {

                return Json(new { success = false, data = ex.Message }, JsonRequestBehavior.AllowGet);// Return  As JSON Result
            }
        }

        public JsonResult DeleteEmployee(int Id)
        {

            try
            {

                HttpClient webApiClient = new HttpClient();//Consume Web Api Using HttpClient
                webApiClient.BaseAddress = new Uri("https://localhost:44342/api/");//We have to pass base address for the wep api project
                webApiClient.DefaultRequestHeaders.Clear();//Clear Defalt Request Header
                webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//Set media type as JSON
                
                HttpResponseMessage msg = webApiClient.DeleteAsync("Employee/" + Id).Result;//Set Rest Url Of Web Api to Delete the Employee Record
                var result = "Record deleted Successfully !!!";//to Set Message after record deleted

                return Json(new { success = true, Data = result }, JsonRequestBehavior.AllowGet);// Return  As JSON Result
            }
            catch (Exception ex)
            {

                return Json(new { success = false, data = ex.Message }, JsonRequestBehavior.AllowGet);// Return  As JSON Result
            }
        }
    }
}