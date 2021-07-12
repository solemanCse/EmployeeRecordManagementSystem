using EmployeeRecordWeb.Controllers;
using EmployeeRecordWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmployeeRecordWeb.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
            EmployeeController empController = new EmployeeController();
            //Act
            ActionResult result = empController.Index() as ActionResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetEmpoyee()
        {
            //Arrange
            EmployeeController empController = new EmployeeController();
            //Act
            JsonResult testResult = empController.GetAllEmployee() as JsonResult;
            //Assert
            Assert.IsNotNull(testResult.Data); 
        }
        [TestMethod]
        public void GetSpecificEmpoyee()
        {
            //Arrange
            EmployeeController empController = new EmployeeController();
            //Act
            JsonResult testResult = empController.GetSpecificEmployee(1) as JsonResult;
            //Assert
            Assert.IsNotNull(testResult.Data);
        }
        [TestMethod]
        public void SaveEmployeeRecord()
        {
            //Arrange
            EmployeeModel employeeObj = new EmployeeModel();
            employeeObj.Id = 0;
            employeeObj.FirstName = "Abdullah";
            employeeObj.MiddleName = "Al";
            employeeObj.LastName = "Minhaj";
            EmployeeController empController = new EmployeeController();
            //Act
            JsonResult testResult = empController.SaveOrUpdateEmployee(employeeObj) as JsonResult;
            //Assert
            Assert.IsNotNull(testResult.Data);
        }
        [TestMethod]
        public void UpdateEmployeeRecord()
        {
            //Arrange
            EmployeeModel employeeObj = new EmployeeModel();
            employeeObj.Id = 1;
            employeeObj.FirstName = "Abdullah";
            employeeObj.MiddleName = "Al";
            employeeObj.LastName = "Minhaz";
            EmployeeController empController = new EmployeeController();
            //Act
            JsonResult testResult = empController.SaveOrUpdateEmployee(employeeObj) as JsonResult;
            //Assert
            Assert.IsNotNull(testResult.Data);
        }
        [TestMethod]
        public void DeleteSpecificEmpoyee()
        {
            //Arrange
            EmployeeController empController = new EmployeeController();
            //Act
            JsonResult testResult = empController.DeleteEmployee(1) as JsonResult;
            //Assert
            Assert.IsNotNull(testResult.Data);
        }
    }
}
