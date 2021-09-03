using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETcore.Base;
using NETcore.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETcore.Model;
using System.Net;
using NETcore.ViewModel;

namespace NETcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : BaseController<Person, PersonRepository, string>
    {
        private readonly PersonRepository repository;
        public PersonsController(PersonRepository repository) : base(repository)
        {
            this.repository = repository;

        }
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
                return Ok( new
                {
                    status = HttpStatusCode.OK,
                    result = getRegister,
                    message = " Succes",
                });
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
                return StatusCode((int)HttpStatusCode.OK, new
                {
                    status = (int)HttpStatusCode.OK,
                    result = registerVM,
                    message = " Succes",
                });
            }
        }
        [HttpPost("Register")]
        public ActionResult GetRegister(RegisterVM register)
        {
            try
            {
                if (repository.InsertRegister(register) > 0)
                {
                    return Ok(new { status = HttpStatusCode.OK, message = "Data Berhasil ditambahkan" });

                }
                else if (repository.InsertRegister(register) == 0)
                {
                    return BadRequest(new
                    {
                        status = HttpStatusCode.BadRequest,
                        message = "Gagal Menambahkan Data "
                    });
                }
                else
                {
                    return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data sudah ada" });

                }

            }
            catch (Exception e)
            {

                return BadRequest(new { status = HttpStatusCode.BadRequest, message = e.Message });
            }
        }
    }
}
