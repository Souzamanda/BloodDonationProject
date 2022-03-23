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
    public class DonationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DonationController> _logger;
        private readonly IMapper _mapper;
        public DonationController(IUnitOfWork unitOfWork, ILogger<DonationController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDonations()
        {
            try
            {
                var donations = await _unitOfWork.Donations.GetAll();
                var results = _mapper.Map<IList<DonationDTO>>(donations);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetDonations)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDonation(int id)
        {
            try
            {
                var donation = await _unitOfWork.Donations.Get(q => q.Id == id, new List<string> { "User", "Hospital" });
                var result = _mapper.Map<DonationDTO>(donation);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetDonation)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}
