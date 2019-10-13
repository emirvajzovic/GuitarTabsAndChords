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
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistsService _service;

        public ArtistsController(IArtistsService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Artists> Get([FromQuery] Model.Requests.ArtistsSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{Id}")]
        public Model.Artists GetById(int Id)
        {
            return _service.GetById(Id);
        }

        [HttpPost]
        public Model.Artists Insert([FromBody] Model.Requests.ArtistsInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{Id}")]
        [Authorize(Roles="Administrator")]
        public Model.Artists Update(int Id, [FromBody] Model.Requests.ArtistsInsertRequest request)
        {
            return _service.Update(Id, request);
        }

    }
}