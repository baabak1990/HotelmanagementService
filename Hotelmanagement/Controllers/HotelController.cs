using AutoMapper;
using Hotelmanagment.Application.Contract.Repository;
using Hotelmanagment.Application.DTO.CountyDTO;
using Hotelmanagment.Application.DTO.HotleDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Hotelmanagment.Application.DTO.UserDTO.Validation;
using Hotelmanagment.Application.DTO.HotleDTO.Validations;
using Hotlemanagment.Domain.Entity.Entities;
using Microsoft.Extensions.Logging;

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


        [HttpGet("{id:int}", Name = "GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //ToDo: Check Auth Problem Later
        //[Authorize(Roles = "Admin")]
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

        [HttpPost]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateHotel(CreateHotelDTo hotelDto)
        {
            var validation = new CreateHotelDOTValidation();
            var validationResult = await validation.ValidateAsync(hotelDto);
            if (validationResult.IsValid == false)
            {
                _logger.LogError("Validation Error Happened");
                return BadRequest();
            }

           
            try
            {
                var hotel = _mapper.Map<Hotel>(hotelDto);
                hotel.CreateDate=DateTime.Now;
                hotel.CreationNote = "Created By Admin";
                await _unitOfWork.Hotel.Add(hotel);
                await _unitOfWork.Save();
                return CreatedAtRoute("GetHotel", new { id = hotel.Id },hotel);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error Happened While Try To Create New Hotel!");
                throw new Exception("Some thing Went Wrong !!! Please Try Again");
                return StatusCode(500);
            }

           
        }


    }
}
