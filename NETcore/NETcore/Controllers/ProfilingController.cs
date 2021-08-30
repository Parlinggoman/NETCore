using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETcore.Base;
using NETcore.Model;
using NETcore.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilingController : BaseController<Profiling, ProfilingRepository, string>
    {
        public ProfilingController(ProfilingRepository repository) : base(repository)
        {
        }
    }
}
