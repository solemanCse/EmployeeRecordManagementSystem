using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeRecordWeb.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}