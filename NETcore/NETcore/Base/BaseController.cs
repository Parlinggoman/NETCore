using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class BaseController <Entity,Repository,Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity,Key>
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
        //public ActionResult Insert(Person person)
        //{

        //    try
        //    {
        //        if (personRepository.Insert(person)>0)
        //        {
        //            return Ok( "Data Berhasil ditambahkan");

        //        }
        //        else if (personRepository.Insert(person)==0)
        //        {
        //            return BadRequest( "Gagal Menambahkan Data" );

        //        }
        //    }
        //    catch (Exception )
        //    {

        //        return BadRequest("Data Sudah Ada");
        //    }

        //  //  personRepository.Insert(person);
        //   // return Ok();
        //}

        [HttpPut]
        public ActionResult Update(Entity entity)
        {
            var data = repository.Update(entity);
            try
            {
                if (data != 0)
                {
                    return Ok(new { status = HttpStatusCode.OK, data, message = "Data Berhasil diupdate" });
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR :" + e.Message);
            }
            return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data tidak ditemukan" });
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
            var data = repository.Delete(key);
            if (data == 0)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Gagal dihapus" });
            }
            repository.Delete(key);
            return Ok(new { status = HttpStatusCode.OK, message = "Data Berhasil dihapus" });
        }
    }
}
