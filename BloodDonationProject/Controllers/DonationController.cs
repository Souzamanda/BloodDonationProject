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

        [HttpGet("{id:int}", Name = "GetDonation")]
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateDonation([FromBody] CreateDonationDTO donationDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateDonation)}");
                return BadRequest(ModelState);
            }

            try
            {
                var donation = _mapper.Map<Donation>(donationDTO);
                await _unitOfWork.Donations.Insert(donation);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetDonation", new { id = donation.Id }, donation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateDonation)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDonation(int id, [FromBody] UpdateDonationDTO donationDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonation)}");
                return BadRequest(ModelState);
            }

            try
            {
                var donation = await _unitOfWork.Donations.Get(q => q.Id == id);
                if (donation == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonation)}");
                    return BadRequest("Submitted data is invalid");
                }

                _mapper.Map(donationDTO, donation);
                _unitOfWork.Donations.Update(donation);
                await _unitOfWork.Save();

                return AcceptedAtRoute("GetDonation", new { id = donation.Id }, donation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateDonation)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}
