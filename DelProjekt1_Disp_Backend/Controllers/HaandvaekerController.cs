using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DelProjekt1_Disp_Backend.Services;
using DelProjekt1_Disp_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DelProjekt1_Disp_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HaandvaekerController : ControllerBase
    {
        private readonly ILogger<HaandvaekerController> _logger;
        private readonly HaandvaerkerService _service;

        public HaandvaekerController(ILogger<HaandvaekerController> logger)
        {
            _logger = logger;
            _service = new HaandvaerkerService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Haandvaerker>> GetAll()
        {
            var haandvaerkere =  _service.GetAllHandvaekere();
            
            if (haandvaerkere == null)
            {
                return NotFound();
            }

            return Ok(haandvaerkere);
        }

        [HttpPost]
        public ActionResult<Haandvaerker> PostHaandvaeker(Haandvaerker Haandvaerker)
        {
            var result = _service.AddHandvaeker(Haandvaerker);
            
            if (result == null)
            {
                return BadRequest();
            }
            
            return Ok(result);
        }
    }
}
