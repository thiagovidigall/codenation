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
    public class CandidateController : ControllerBase
    {
        IMapper _mapper;
        ICandidateService _service;

        public CandidateController(ICandidateService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        // GET api/candidate
        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? companyId = null, int? accelerationId = null)
        {
            try
            {
                IList<Candidate> candidates = new List<Candidate>();

                if ((accelerationId == null && companyId == null) || (accelerationId != null && companyId != null))
                    return NoContent();

                if (accelerationId != null)
                    candidates = _service.FindByAccelerationId((int)accelerationId);

                if (companyId != null)
                    candidates = _service.FindByCompanyId((int)companyId);

                var result = _mapper.Map<List<CandidateDTO>>(candidates);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/candidate/{userId}/{accelerationId}/{companyId}
        [HttpGet]
        [Route("api/candidate/{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            try
            {
                var candidate = _service.FindById(userId, accelerationId, companyId);
                var result = _mapper.Map<CandidateDTO>(candidate);
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

        // POST api/candidate
        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            try
            {
                Candidate candidate = _mapper.Map<Candidate>(value);

                if (candidate == null)
                    return BadRequest();

                _service.Save(candidate);
                var result = _mapper.Map<CandidateDTO>(candidate);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}