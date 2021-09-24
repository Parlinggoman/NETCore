using ImplementCors.Base.Controllers;
using ImplementCors.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementCors.Controllers
{
    //public class DistrictsController : BaseController<District, DistrictRepository, string>
    //{
    //    private readonly DistrictRepository repository;
    //    public DistrictsController(DistrictRepository repository) : base(repository)
    //    {
    //        this.repository = repository;
    //    }

    //    [HttpGet]
    //    public async Task<JsonResult> GetByProvinceId(int id)
    //    {
    //        var result = await repository.GetByProvinceId(id);
    //        return Json(result);
    //    }

    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}

}
