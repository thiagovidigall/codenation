using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        IMapper _mapper;
        ISubmissionService _service;

        public SubmissionController(ISubmissionService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        // GET api/challenge
        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? challengeId = null, int? accelerationId = null)
        {
            try
            {
                IList<Submission> submissions = new List<Submission>();

                if (challengeId == null && accelerationId == null)
                    return NoContent();

                submissions = _service.FindByChallengeIdAndAccelerationId((int)challengeId, (int)accelerationId);

                var result = _mapper.Map<List<SubmissionDTO>>(submissions);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/submission/higherScore")]
        public ActionResult<SubmissionDTO> Get(int challengeId)
        {
            try
            {
                if (challengeId == 0)
                    return NoContent();

                var submission = _service.FindHigherScoreByChallengeId(challengeId);
                var result = _mapper.Map<SubmissionDTO>(submission);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/submission
        [HttpPost]        
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            try
            {
                Submission submission = _mapper.Map<Submission>(value);

                if (submission == null)
                    return BadRequest();

                _service.Save(submission);
                var result = _mapper.Map<SubmissionDTO>(submission);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
