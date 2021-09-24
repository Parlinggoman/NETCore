using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETcore.Base;
using NETcore.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using NETcore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using NETcore.Models;
using Microsoft.AspNetCore.Cors;

namespace NETcore.Controllers
{
    [EnableCors("AllowAllOrigins")]
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : BaseController<Person, PersonRepository, string>
    {
        private readonly PersonRepository repository;
        private readonly RoleRepository roleRepository;
        public PersonsController(PersonRepository repository,RoleRepository roleRepository) : base(repository)
        {
            this.repository = repository;
            this.roleRepository = roleRepository;

        }
      //[Authorize(Roles ="User")]
       [EnableCors("AllowAllOrigins")]
        [HttpGet("GetRegisterVM")]
        public ActionResult GetRegister()
        {


            var getRegister = repository.RegisterVMs();
            if (getRegister == null)
            {
                return NotFound(
                   new
                   {
                       status = HttpStatusCode.NotFound,
                       result = getRegister,
                       message = " Data tidak Ditemukan",

                   });
            }
            else
            {
                //return Ok(new
                //{
                //    status = HttpStatusCode.OK,
                //    result = getRegister,
                //    message = " Succes",
                //});
                return Ok(getRegister);
            }
            //{
            //    var get = Ok(new { status = HttpStatusCode.OK, result = registerVM, message = "Succes" });
            //    return get;
            //}
            //else
            //{
            //    var get = NotFound(new { status = HttpStatusCode.NotFound, result = registerVM, message = "Data Empty" });
            //    return get;
            //}

        }

        //private ActionResult StatusCodes(int notFound, object p)
        //{
        //    throw new NotImplementedException();
        //}
        //[Authorize]
        [EnableCors("AllowAllOrigins")]
        [HttpGet("GetRegister/{NIK}")]
        public ActionResult GetRegister(string NIK)
        {


            var registerVM = repository.GetRegister(NIK);
            if (registerVM == null)
            {
                return StatusCode(
                     (int)HttpStatusCode.NotFound, new
                     {
                         status = (int)HttpStatusCode.NoContent,
                         result = registerVM,
                         message = " Data tidak Ditemukan",

                     });
            }
            else
            {
                //return StatusCode((int)HttpStatusCode.OK, new
                //{
                //    status = (int)HttpStatusCode.OK,
                //    result = registerVM,
                //    message = " Succes",
                //});
                return Ok(registerVM);
            }
        }
        [EnableCors("AllowAllOrigins")]
        [HttpPost("register")]
        public object InsertRegister(RegisterVM registerVM)
        {
            try
            {
                string massage = repository.ValidationUnique(registerVM.NIK, registerVM.Email, registerVM.PhoneNumber);
                if (massage != "1")
                {
                    return StatusCode((int)HttpStatusCode.BadGateway, new
                    {
                        StatusCode = (int)HttpStatusCode.BadGateway,
                        message = massage
                    });
                }

                //check role user
                registerVM.RoleId = roleRepository.getIdByName("User");

                if (repository.InsertRegister(registerVM) == 1)
                {
                    return Ok(new
                    {
                        StatusCode = HttpStatusCode.OK,
                        message = "Success register"
                    });
                };

                return StatusCode((int)HttpStatusCode.BadGateway, new
                {
                    status = (int)HttpStatusCode.BadGateway,
                    message = "Gagal Register"
                });
            }
            catch (System.Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    status = (int)HttpStatusCode.InternalServerError,
                    message = e.Message
                });
            }
        }
        [HttpPost("addrole")]
        public ActionResult AddAccountRole(AccountRole accountRole)
        {
            try
            {
                var test = accountRole;

                repository.AddNewAccountRole(accountRole.NIK, accountRole.RoleId);

                return StatusCode((int)HttpStatusCode.Created, new
                {
                    status = (int)HttpStatusCode.Created,
                    message = "Success created"
                });

            }
            catch (System.Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    status = (int)HttpStatusCode.InternalServerError,
                    message = e.Message
                });
            }
        }
    }
}
