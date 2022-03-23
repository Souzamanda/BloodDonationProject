using AutoMapper;
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

        [HttpGet("{id:int}")]
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
    }
}
