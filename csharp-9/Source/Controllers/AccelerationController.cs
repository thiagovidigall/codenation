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
    public class AccelerationController : ControllerBase
    {
        IMapper _mapper;
        IAccelerationService _service;

        public AccelerationController(IAccelerationService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        // GET api/acceleration
        [HttpGet]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll(int? companyId = null)
        {
            try
            {
                IList<Acceleration> acceleration = new List<Acceleration>();

                if (companyId == null)
                    return NoContent();

                acceleration = _service.FindByCompanyId((int)companyId);

                var result = _mapper.Map<List<AccelerationDTO>>(acceleration);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/acceleration/{id}
        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            try
            {
                var acceleration = _service.FindById(id);
                var result = _mapper.Map<AccelerationDTO>(acceleration);
                if (result == null || result.Id != id)
                {
                    return NotFound(id);
                }
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/acceleration
        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody] AccelerationDTO value)
        {
            try
            {
                Acceleration user = _mapper.Map<Acceleration>(value);

                if (user == null)
                    return BadRequest();

                _service.Save(user);
                var result = _mapper.Map<AccelerationDTO>(user);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
