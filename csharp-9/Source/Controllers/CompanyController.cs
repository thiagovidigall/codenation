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
    public class CompanyController : ControllerBase
    {
        IMapper _mapper;
        ICompanyService _service;

        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        // GET api/company
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            try
            {
                IList<Company> companies = new List<Company>();

                if ((accelerationId == null && userId == null) || (accelerationId != null && userId != null))
                    return NoContent();

                if (accelerationId != null)
                    companies = _service.FindByAccelerationId((int)accelerationId);

                if (userId != null)
                    companies = _service.FindByUserId((int)userId);

                var result = _mapper.Map<List<CompanyDTO>>(companies);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            try
            {
                var company = _service.FindById(id);
                var result = _mapper.Map<CompanyDTO>(company);
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

        // POST api/company
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            try
            {
                Company company = _mapper.Map<Company>(value);

                if (company == null)
                    return BadRequest();

                _service.Save(company);
                var result = _mapper.Map<CompanyDTO>(company);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
