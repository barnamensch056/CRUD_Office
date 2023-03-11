using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeWebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace OfficeWebApi.Data
{
    public interface IEmployeeRepository
    {
        public JsonResult GetEmp();
        public JsonResult GetAllEmployees();
        public JsonResult PostEmp(Employee emp);
        public JsonResult PutEmp(Employee emp);
        public JsonResult DeleteEmp(int id);
    }
}
