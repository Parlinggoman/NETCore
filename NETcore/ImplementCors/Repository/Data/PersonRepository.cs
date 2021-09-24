using ImplementCors.Base.Urls;
using Microsoft.AspNetCore.Http;
using NETcore.Models;
using NETcore.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ImplementCors.Repository.Data
{
    public class PersonRepository : GeneralRepository<Person, string>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public PersonRepository(Address address, string request = "Persons/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
        }
        public async Task<List<RegisterVM>> GetAllProfile()
        {
            List<RegisterVM> registers = new List<RegisterVM>();

            using (var response = await httpClient.GetAsync(request + "GetRegisterVM"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                registers= JsonConvert.DeserializeObject<List<RegisterVM>>(apiResponse);
            }
            return registers;
        }
        public async Task<RegisterVM> GetById(string NIK)
        {
            RegisterVM register = new RegisterVM();

            using (var response = await httpClient.GetAsync(request + "GetRegister/" + NIK))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                register = JsonConvert.DeserializeObject<RegisterVM>(apiResponse);
            }
            return register;
        }
     

        //public HttpStatusCode Register(RegisterVM register)
        //{
        //    StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
        //    var result = httpClient.PostAsync(address.link + request + "Register", content).Result;
        //    return result.StatusCode;
        //}

        public string Registerdata(RegisterVM registerVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(request + "Register", content).Result.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
