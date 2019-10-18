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
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumsService _service;

        public AlbumsController(IAlbumsService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Albums> Get([FromQuery] Model.Requests.AlbumsSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{Id}")]
        public Model.Albums GetById(int Id)
        {
            return _service.GetById(Id);
        }

        [HttpPost]
        public Model.Albums Insert([FromBody] Model.Requests.AlbumsInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{Id}")]
        [Authorize(Roles="Administrator")]
        public Model.Albums Update(int Id, [FromBody] Model.Requests.AlbumsInsertRequest request)
        {
            return _service.Update(Id, request);
        }

    }
}