using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GuitarTabsAndChords.WebAPI.Services;

namespace GuitarTabsAndChords.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class RecommenderController : ControllerBase
    {
        private readonly IRecommenderService _service;

        public RecommenderController(IRecommenderService service)
        {
            _service = service;
        }

        [HttpGet("GetRecommendedNotations")]
        public List<Model.Notations> GetRecommendedNotations()
        {
            return _service.GetRecommendedNotations();
        }

    }
}