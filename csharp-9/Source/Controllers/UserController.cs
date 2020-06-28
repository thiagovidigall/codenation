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
    public class UserController : ControllerBase
    {
        IMapper _mapper;
        IUserService _service;
        
        public UserController(IUserService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {
            try
            {
                IList<User> users = new List<User>();

                if ((accelerationName == null && companyId == null) || (accelerationName != null && companyId != null))
                    return NoContent();

                if (accelerationName != null)
                    users = _service.FindByAccelerationName(accelerationName);

                if (companyId != null)
                    users = _service.FindByCompanyId((int)companyId);

                var result = _mapper.Map<List<UserDTO>>(users);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            try
            {
                var user = _service.FindById(id);
                var result = _mapper.Map<UserDTO>(user);
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

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            try
            {
                User user = _mapper.Map<User>(value);

                if (user == null)
                    return BadRequest();
                
                _service.Save(user);
                var result = _mapper.Map<UserDTO>(user);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }   
     
    }
}
