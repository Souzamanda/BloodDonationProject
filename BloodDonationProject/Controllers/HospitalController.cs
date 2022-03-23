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
    public class HospitalController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HospitalController> _logger;
        private readonly IMapper _mapper;
        public HospitalController(IUnitOfWork unitOfWork, ILogger<HospitalController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHospitals()
        {
            try
            {
                var hospitals = await _unitOfWork.Hospitals.GetAll();
                var results = _mapper.Map<IList<HospitalDTO>>(hospitals);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetHospitals)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHospital(int id)
        {
            try
            {
                var hospital = await _unitOfWork.Hospitals.Get(q => q.Id == id, new List<string> { "Donations" });
                var result = _mapper.Map<HospitalDTO>(hospital);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetHospital)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}
