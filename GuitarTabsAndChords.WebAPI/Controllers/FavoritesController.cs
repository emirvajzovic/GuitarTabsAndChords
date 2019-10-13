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
    [Authorize(Roles = "User")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesService _service;

        public FavoritesController(IFavoritesService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Favorites> Get([FromQuery] Model.Requests.FavoritesSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{Id}")]
        public Model.Favorites GetById(int Id)
        {
            return _service.GetById(Id);
        }

        [HttpPost]
        public Model.Favorites Insert([FromBody] Model.Requests.FavoritesInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}