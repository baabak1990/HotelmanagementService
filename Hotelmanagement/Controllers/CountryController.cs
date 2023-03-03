using AutoMapper;
using Hotelmanagment.Application.Contract.Repository;
using Hotelmanagment.Application.DTO.CountyDTO;
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
        public async Task<ActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAllAsync();
                var result = _mapper.Map<List<CountryDTO>>(countries);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong With {GetCountries()}");
                return StatusCode(500, "the Error Occurred During This process , Please Try leater ");
            }
        }

        [HttpGet("{id:int}")]
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

    }
}
