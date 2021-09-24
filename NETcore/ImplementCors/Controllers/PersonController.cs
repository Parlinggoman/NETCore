using ImplementCors.Base.Controllers;
using ImplementCors.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using NETcore.Models;
using NETcore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementCors.Controllers
{
    [Route("[controller]")]
    public class PersonController : BaseController<Person,PersonRepository, string>
    {
        PersonRepository personRepository;

        public PersonController(PersonRepository personRepository) : base(personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpPost("PostReg")]
        public JsonResult PostReg(RegisterVM registerVM)
        {
            var result = personRepository.Registerdata(registerVM);
            return Json(result);
        }


        [HttpGet("GetAlldata")]
        public async Task<JsonResult> GetAlldata()
        {
            var result = await personRepository.GetAllProfile();
            return Json(result);
        }
        
        [HttpGet("GetBynik/{NIK}")]
        public async Task<JsonResult> GetBynik(string NIK)
        {
            var result = await personRepository.GetById(NIK);
            return Json(result);
        }

        //[HttpPost("Register")]
        //public async Task(JsonResult) Register(RegisterVM registerVM)
        //{
        //    var result = await repository.Register(registerVM);
        //    return Json(result);
        //}
        
      

     
        public IActionResult Index()
        {
            return View();
        }
    }
}
