using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OfficeWebApi.Models;
using OfficeWebApi.Data;
namespace OfficeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DepartmentController : ControllerBase
    {
        IDepartmentRepository repo;

        //private readonly IConfiguration _configuration;
        public DepartmentController( IDepartmentRepository repo)
        {
            this.repo = repo;
        //    _configuration = configuration;
        }
        [HttpGet]
            
            public JsonResult Get()
        {
            return repo.GetDept();

        }
            
        [HttpPost]
        public JsonResult Post(Department dept)
        {
            return repo.PostDept(dept);
        }
        
         [HttpPut]
         public JsonResult Put(Department dep)
        {
            return repo.PutDept(dep);
        }
     
        
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            return repo.DeleteDept(id);
        }
        
    }
}
