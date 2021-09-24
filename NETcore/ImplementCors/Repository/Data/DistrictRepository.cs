using ImplementCors.Base.Urls;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ImplementCors.Repository.Data
{
    public class DistrictRepository { }
    //{
    //    private readonly Address address;
    //    private readonly string request;
    //    private readonly IHttpContextAccessor _contextAccessor;
    //    private readonly HttpClient httpClient;

    //    public DistrictRepository(Address address, string request = "Districts/") : base(address, request)
    //    {
    //        this.address = address;
    //        this.request = request;
    //        //_contextAccessor = new HttpContextAccessor();
    //        //httpClient = new HttpClient
    //        //{
    //        //    BaseAddress = new Uri(address.link)
    //        //};
    //        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
    //    }

    //    public async Task<List<District>> GetByProvinceId(int provinceId)
    //    {
    //        List<District> entities = new List<District>();

    //        using (var response = await httpClient.GetAsync(request + "getbyprovinceid/" + provinceId))
    //        {
    //            string apiResponse = await response.Content.ReadAsStringAsync();
    //            entities = JsonConvert.DeserializeObject<List<District>>(apiResponse);
    //        }
    //        return entities;
    //    }
    //}
}
