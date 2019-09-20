using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabsAndChords.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuitarTabsAndChords.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongsService _service;

        public SongsController(ISongsService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Songs> Get([FromQuery] Model.Requests.SongsSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{Id}")]
        public Model.Songs GetById(int Id)
        {
            return _service.GetById(Id);
        }

        [HttpPost]
        public Model.Songs Insert([FromBody] Model.Requests.SongsInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{Id}")]
        public Model.Songs Update(int Id, [FromBody] Model.Requests.SongsInsertRequest request)
        {
            return _service.Update(Id, request);
        }

    }
}