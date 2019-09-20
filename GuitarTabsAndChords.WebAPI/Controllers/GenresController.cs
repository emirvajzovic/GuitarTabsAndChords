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
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _service;

        public GenresController(IGenresService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Genres> Get([FromQuery] Model.Requests.GenresSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{Id}")]
        public Model.Genres GetById(int Id)
        {
            return _service.GetById(Id);
        }

        [HttpPost]
        public Model.Genres Insert([FromBody] Model.Requests.GenresInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{Id}")]
        public Model.Genres Update(int Id, [FromBody] Model.Requests.GenresInsertRequest request)
        {
            return _service.Update(Id, request);
        }

    }
}