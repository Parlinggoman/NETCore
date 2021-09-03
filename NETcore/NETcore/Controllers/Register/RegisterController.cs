using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETcore.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        //nambah konstructer
        private readonly AccountRepository accountRepository;
        private readonly EducationRepository educationRepository;
        private readonly PersonRepository personRepository;
        private readonly ProfilingRepository profilingRepository;
        private readonly UniversityRepository universityRepository;

        public RegisterController
            (
            AccountRepository accountRepository,
            EducationRepository educationRepository,
            PersonRepository personRepository,
            ProfilingRepository profilingRepository,
            UniversityRepository universityRepository
            )
        {
            this.accountRepository = accountRepository;
            this.educationRepository = educationRepository;
            this.personRepository = personRepository;
            this.profilingRepository = profilingRepository;
            this.universityRepository = universityRepository;
        }


    }


    //[HttpGet("{GetRegister}")]
    //public ActionResult GetRegister()
    //{


    //    var getRegister = repository.GetRegisterVM();
    //    if (getRegister != null)
    //    {
    //        var get = Ok(new { status = HttStatusCode.Ok, result =})


    //    }
    //    return NotFound(new
    //    {
    //        status = HttpStatusCode.NotFound,
    //        message = "Data yang Anda Pilih Tidak Ada"
    //    });
    //}
}
