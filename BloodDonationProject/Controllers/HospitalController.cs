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

        [HttpGet("{id:int}", Name ="GetHospital")]
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateHospital([FromBody] CreateHospitalDTO hospitalDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateHospital)}");
                return BadRequest(ModelState);
            }

            try
            {
                var hospital = _mapper.Map<Hospital>(hospitalDTO);
                await _unitOfWork.Hospitals.Insert(hospital);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetHospital", new { id = hospital.Id }, hospital);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateHospital)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateHospital(int id, [FromBody] UpdateHospitalDTO hospitalDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateHospital)}");
                return BadRequest(ModelState);
            }

            try
            {
                var hospital = await _unitOfWork.Hospitals.Get(q => q.Id == id);
                if (hospital == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateHospital)}");
                    return BadRequest("Submitted data is invalid");
                }

                _mapper.Map(hospitalDTO, hospital);
                _unitOfWork.Hospitals.Update(hospital);
                await _unitOfWork.Save();

                return AcceptedAtRoute("GetHospital", new { id = hospital.Id }, hospital);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateHospital)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteHospital)}");
                return BadRequest();
            }

            try
            {
                var hospital = await _unitOfWork.Hospitals.Get(q => q.Id == id);
                if (hospital == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteHospital)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Hospitals.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteHospital)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}
