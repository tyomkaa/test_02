using Kolos_02.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_02.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IDBMusician _dBMusician;

        private MusicianController(IDBMusician dBMusician)
        {
            _dBMusician = dBMusician;
        }

        [HttpGet("{idMusician")]
        public IActionResult GetMusician(int idMusician)
        {
            try
            {
                var response = _dBMusician.getMusician(idMusician);
                return Ok(response);
            }
            catch
            {
                throw new Exception();            
            }
        }

        [HttpPost]
    }
}
