using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITT_API.Controllers
{
    
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult Register()
        {

        }
    }
}
