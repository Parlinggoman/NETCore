using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETcore.Controllers;
using NETcore.Repository.Data;
using NETcore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NETcore.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;
   

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

    
        

        //public BaseController(AccountRepository repository)
        //{
        //    this.repository = repository;
        //}
        //[HttpPost]
        //public ActionResult Insert(Entity entity)
        //{
        //    try
        //    {
        //        repository.Insert(entity);
        //        return Ok(new
        //        {
        //            statusCode = StatusCode(200),
        //            status = HttpStatusCode.OK,
        //            message = "Success"
        //        });
        //    }
        //    catch
        //    {
        //        return BadRequest(new
        //        {
        //            status = HttpStatusCode.BadRequest,
        //            message = "Error duplicate data",
        //            error = entity,
        //        });
        //    }
        //}
        [HttpPost]
        public ActionResult Insert(Entity entity)
        {
            try
            {
                if (repository.Insert(entity) > 0)
                {
                    return Ok(new { status = HttpStatusCode.OK, message = "Data Berhasil ditambahkan" });
                }
                else if (repository.Insert(entity) == 0)
                {
                    return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Gagal Menambahkan Data" });
                }
                else
                {
                    return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Sudah ada" });
                }
            }
            catch (Exception)
            {

                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Sudah ada" });
            }

        }

        [HttpPut]

        public ActionResult Update(Key key, Entity entity)
        {
            //personRepository.Update(person);
            //return Ok();
            try
            {
                if (repository.Update(entity) != 0)
                {
                    return Ok(new
                    {
                        status = HttpStatusCode.OK,
                        //data = repository.Get(entity.key),
                        message = "Data berhasil Di Update"
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return NotFound(new
            {
                status = HttpStatusCode.NotFound,
                message = "Data dengan NIK Tidak Ditemukan"
            });

        }
        [HttpGet]
        public ActionResult Get()
        {
            var data = repository.Get();
            if (data.Count() == 0)
            {

                return NotFound(new { status = HttpStatusCode.NotFound, message = "Data Kosong" });
            }
            return Ok(new { status = HttpStatusCode.OK, data, message = "Data Berhasil ditampilkan" });
        }
        [HttpGet("{key}")]
        public ActionResult Get(Key key)
        {
            var data = repository.Get(key);
            //Jika data yang dicari tidak ada
            if (data == null)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Kamu salah input data gaada" });
            }
            return Ok(new { status = HttpStatusCode.OK, data, message = "Data ditemukan" });
        }

        //[HttpGet("{key}")]
        //public ActionResult Get(Key key)
        //{

        //    //return Ok(personRepository.Get(NIK));
        //    if (repository.Get(key) != null)
        //    {

        //        return Ok(new
        //        {
        //            status = HttpStatusCode.OK,
        //            data = repository.Get(key),
        //            message = "Data Berhasil Ditampilkan"
        //        });
        //    }
        //    return NotFound(new
        //    {
        //        status = HttpStatusCode.NotFound,
        //        message = "Data yang Anda Pilih Tidak Ada"
        //    });
        //}


        //public ActionResult Get(string NIK)
        //{
        //    if (personRepository.Get(NIK) != null)
        //    {
        //        return Ok(new
        //            {
        //            Status = HttpStatusCode.OK,
        //                data = personRepository.Get(NIK),
        //                message = "Data Berhasil di Tampilkan"


        //            }
        //    );
        //}
        //return BadRequest("Data tidak ada");
        //// return Ok(personRepository.Get());
        //}



        [HttpDelete("{key}")]
        public ActionResult Delete(Key key)
        {
            //personRepository.Delete(NIK);
            //return Ok("Data Berhasil Dihapus");
            if (repository.Get(key) != null)
            {
                repository.Delete(key);
                return Ok(new
                {
                    status = HttpStatusCode.OK,
                    data = repository.Get(key),
                    deletedata = repository.Delete(key),
                    message = "Data berhasil Dihapus"
                });
            }
            else
            {
                return NotFound(new
                {
                    status = HttpStatusCode.NotFound,
                    message = "Data Tidak Ditemukan"
                });
            }
        }
    }
}
