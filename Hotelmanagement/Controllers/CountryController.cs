using AutoMapper;
using Hotelmanagment.Application.Contract.Repository;
using Hotelmanagment.Application.DTO.CountyDTO;
using Hotelmanagment.Application.DTO.CountyDTO.Validations;
using Hotlemanagment.Domain.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotelmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        #region Constructor

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        #endregion
        #region Get
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCountries([FromQuery] RequestParams requestParams)
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAllWithPaging(requestParams);
                var result = _mapper.Map<List<CountryDTO>>(countries);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong With {GetCountries(requestParams)}");
                return StatusCode(500, "the Error Occurred During This process , Please Try leater ");
            }
        }

        [HttpGet("{id:int}", Name = "GetCountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.GetAsync(c => c.Id == id);
                var result = _mapper.Map<CountryDTO>(country);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong with {GetCountry(id)}");
                return StatusCode(500);
            }
        }
        #endregion

        #region Create And Edit

        [HttpPost]
        [Route("CreateCountry")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateCountry([FromBody] CreateCountryDTO model)
        {
            var validation = new CreateCountryDTOValidations();
            var validator = await validation.ValidateAsync(model);
            if (validator.IsValid == false)
            {
                _logger.LogError($"There Are something wrong in validation of {nameof(model)}");
                return BadRequest(400);
            }

            var hotel = _mapper.Map<Country>(model);
            try
            {
                hotel.CreateDate = DateTime.Now;
                await _unitOfWork.Countries.Add(hotel);
                await _unitOfWork.Save();
                return CreatedAtRoute("GetCountry", new { id = hotel.Id }, hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something happened in creation Process for {nameof(hotel)} ");
                return StatusCode(500);
            }

        }

        #endregion
    }
}
