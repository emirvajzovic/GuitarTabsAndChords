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
    public class NotationCorrectionsController : ControllerBase
    {
        private readonly INotationCorrectionsService _service;

        public NotationCorrectionsController(INotationCorrectionsService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.NotationCorrections> Get()
        {
            return _service.Get();
        }

        [HttpGet("{Id}")]
        public Model.NotationCorrections GetById(int Id)
        {
            return _service.GetById(Id);
        }

        [HttpPost]
        [Authorize(Roles="User")]
        public Model.NotationCorrections Insert([FromBody] Model.Requests.NotationCorrectionsInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{Id}")]
        [Authorize(Roles="Administrator")]
        public Model.NotationCorrections Update(int Id, [FromBody] Model.Requests.NotationCorrectionsUpdateRequest request)
        {
            return _service.Update(Id, request);
        }

    }
}