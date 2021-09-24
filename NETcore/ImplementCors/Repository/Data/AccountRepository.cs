using ImplementCors.Base.Urls;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ImplementCors.Repository.Data
{
    public class AccountRepository { }
//    {
//        private readonly Address address;
//    private readonly string request;
//    private readonly IHttpContextAccessor _contextAccessor;
//    private readonly HttpClient httpClient;
//}
//public AccountRepository(Address address, string request = "Account/") : base(address, request)
//    {
//    this.address = address;
//    this.request = request;
//    //_contextAccessor = new HttpContextAccessor();
//    //httpClient = new HttpClient
//    //{
//    //    BaseAddress = new Uri(address.link)
//    //};
//    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
//}
//public async Task<List<Account>> GetById(string nik)
//{
//    List<Account> entities = new List<Account>();

    //    using (var response = await httpClient.GetAsync(request + "getbyId/" + nik))
    //    {
    //        string apiResponse = await response.Content.ReadAsStringAsync();
    //        entities = JsonConvert.DeserializeObject<List<Account>>(apiResponse);
    //    }
    //    return entities;
    //}

}
