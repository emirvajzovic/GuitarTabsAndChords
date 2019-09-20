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
    public class NotationsController : ControllerBase
    {
        private readonly INotationsService _service;

        public NotationsController(INotationsService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Notations> Get([FromQuery] Model.Requests.NotationsSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{Id}")]
        public Model.Notations GetById(int Id)
        {
            return _service.GetById(Id);
        }

        [HttpPost]
        public Model.Notations Insert([FromBody] Model.Requests.NotationsInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{Id}")]
        public Model.Notations Update(int Id, [FromBody] Model.Requests.NotationsInsertRequest request)
        {
            return _service.Update(Id, request);
        }

    }
}