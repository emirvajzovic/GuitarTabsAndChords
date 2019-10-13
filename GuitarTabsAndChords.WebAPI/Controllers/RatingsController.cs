using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabsAndChords.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuitarTabsAndChords.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingsService _service;

        public RatingsController(IRatingsService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Ratings> Get([FromQuery] Model.Requests.RatingsSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{Id}")]
        public Model.Ratings GetById(int Id)
        {
            return _service.GetById(Id);
        }

        [HttpPost("RateNotation")]
        [Authorize(Roles="User")]
        public Model.Ratings RateNotation([FromBody]Model.Requests.RatingsInsertRequest request)
        {
            return _service.RateNotation(request);
        }
    }
}