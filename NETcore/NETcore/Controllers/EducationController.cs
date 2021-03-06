using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETcore.Base;
using NETcore.Models;
using NETcore.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : BaseController<Education, EducationRepository, int>
    {
        public EducationController(EducationRepository repository) : base(repository)
        {
        }
    }
}
