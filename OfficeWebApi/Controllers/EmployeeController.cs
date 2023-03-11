using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using OfficeWebApi.Models;
using OfficeWebApi.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace OfficeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        IEmployeeRepository repo;
        private readonly IWebHostEnvironment _env;
        public EmployeeController(IEmployeeRepository _repo,IWebHostEnvironment env)
        {
            this.repo = _repo;
            _env = env;
        }
        [HttpGet]
        public JsonResult Get()
        {
            return repo.GetEmp();

        }
        [HttpGet]
        [Route("getAll")]
        public JsonResult GetAllEmployees()
        {
            return repo.GetAllEmployees();

        }
        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            return repo.PostEmp(emp);
        }
        [HttpPut]
        public JsonResult Put(Employee emp)
        {
            return repo.PutEmp(emp);
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            return repo.DeleteEmp(id);

        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos" + filename;
                using (var stream =new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }
    }
}
