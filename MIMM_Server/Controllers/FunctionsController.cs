using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MIMM_Shared.Models;

namespace MIMM_Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FunctionsController : ControllerBase
    {
        private readonly mimmContext _context;

        public FunctionsController(mimmContext context)
        {
            _context = context;
        }

        [HttpGet]
        public String Get()
        {
            const string V = "Hello";
            return V;
        }

    }
}