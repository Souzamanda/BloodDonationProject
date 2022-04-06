using AutoMapper;
using BloodDonationProject.Data;
using BloodDonationProject.IRepository;
using BloodDonationProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _unitOfWork.Users.GetAll();
                var results = _mapper.Map<IList<UserDTO>>(users);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetUsers)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpGet("{id:int}", Name ="GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.Get(q => q.Id == id, new List<string> { "Donations" });
                var result = _mapper.Map<UserDTO>(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetUser)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateUser)}");
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<User>(userDTO);
                await _unitOfWork.Users.Insert(user);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetUser", new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateUser)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO userDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUser)}");
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _unitOfWork.Users.Get(q => q.Id == id);
                if (user == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateUser)}");
                    return BadRequest("Submitted data is invalid");
                }

                _mapper.Map(userDTO, user);
                _unitOfWork.Users.Update(user);
                await _unitOfWork.Save();

                return AcceptedAtRoute("GetUser", new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateUser)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}
