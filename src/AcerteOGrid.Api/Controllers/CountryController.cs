﻿using AcerteOGrid.Communication.Requests.Country;
using Microsoft.AspNetCore.Mvc;

namespace AcerteOGrid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register(ResquestRegisterCountryJson request)
        {
            return Created();
        }
    }
}
