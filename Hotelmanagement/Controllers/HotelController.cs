using AutoMapper;
using Hotelmanagment.Application.Contract.Repository;
using Hotelmanagment.Application.DTO.CountyDTO;
using Hotelmanagment.Application.DTO.HotleDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotelmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        #region Constructor

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, ILogger<HotelController> logger, IMapper mapper)
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
        public async Task<ActionResult> GetHotels()
        {
            try
            {
                var Hoteles = await _unitOfWork.Hotel.GetAllAsync();
                var result = _mapper.Map<List<HotelDTo>>(Hoteles);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong With {GetHotels()}");
                return StatusCode(500, "the Error Occurred During This process , Please Try later ");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Gethotel(int id)
        {
            try
            {
                var Hotel = await _unitOfWork.Hotel.GetAsync(c => c.Id == id);
                var result = _mapper.Map<HotelDTo>(Hotel);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong with {Gethotel(id)}");
                return StatusCode(500);
            }
        }
        #endregion

    }
}
