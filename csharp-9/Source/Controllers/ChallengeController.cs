using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        IMapper _mapper;
        IChallengeService _service;

        public ChallengeController(IChallengeService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        // GET api/challenge
        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            try
            {
                IList<Models.Challenge> challenges = new List<Models.Challenge>();

                if (accelerationId == null && userId == null)
                    return NoContent();

                challenges = _service.FindByAccelerationIdAndUserId((int)accelerationId, (int)userId);

                var result = _mapper.Map<List<ChallengeDTO>>(challenges);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }        

        // POST api/company
        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            try
            {
                Models.Challenge challenge = _mapper.Map<Models.Challenge>(value);

                if (challenge == null)
                    return BadRequest();

                _service.Save(challenge);
                var result = _mapper.Map<ChallengeDTO>(challenge);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
