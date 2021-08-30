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
        private AccountRepository repository1;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        public BaseController(AccountRepository repository1)
        {
            this.repository1 = repository1;
        }

        [HttpPost]
        public ActionResult Insert(Entity entity)
        {
            try
            {
                if (repository.Insert(entity) > 0)
                {
                    return Ok("Data Berhasil Ditambahkan");
                }
                else if (repository.Insert(entity) == 0)
                {
                    return BadRequest("Data Tidak Lengkap");
                }
                else
                {
                    return BadRequest("Data Sudah Ada");
                }
            }
            catch (Exception)
            {
                return BadRequest("Data Sudah Ada");
            }
            //personsRepository.Insert(persons);
            //return BadRequest("Data Sudah Ada");
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

            return Ok(new { status = HttpStatusCode.OK, data, message = "Data Berhasil Ditampilakn" });
        }

        [HttpGet("{key}")]

        public ActionResult Get(Key key )
        {
            var data = repository.Get();
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

            return Ok(new { status = HttpStatusCode.OK, message = "Data Berhasil dihapus" });
        }
    }
}
