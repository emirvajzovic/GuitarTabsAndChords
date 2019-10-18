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
        [Authorize(Roles="Administrator")]
        public Model.Notations Update(int Id, [FromBody] Model.Requests.NotationsInsertRequest request)
        {
            return _service.Update(Id, request);
        }

        [HttpGet("ThisWeekTop5")]
        [Authorize(Roles="User")]
        public List<Model.Notations> GetThisWeekTop5()
        {
            return _service.GetThisWeekTop5();
        }
        [HttpGet("Top100")]
        [Authorize(Roles="User")]
        public List<Model.Notations> GetTop100()
        {
            return _service.GetTop100();
        }
        [HttpGet("PopularNotations")]
        [Authorize(Roles="User")]
        public List<Model.Notations> GetPopularNotations([FromQuery] Model.Requests.NotationsSearchRequest request)
        {
            return _service.GetPopularNotations(request);
        }
    }
}