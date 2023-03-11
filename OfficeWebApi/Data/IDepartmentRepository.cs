using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace OfficeWebApi.Data
{
    public interface IDepartmentRepository
    {
        public JsonResult GetDept();
        public JsonResult PostDept(Department dept);
        public JsonResult PutDept(Department dept);
        public JsonResult DeleteDept(int id);
    }
}
