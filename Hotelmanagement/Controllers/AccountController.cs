using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Hotelmanagment.Application.DTO.UserDTO;
using Hotelmanagment.Application.DTO.UserDTO.Validation;
using Hotlemanagment.Domain.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotelmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        //private readonly SignInManager<ApiUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<ApiUser> userManager/*, SignInManager<ApiUser> signInManager*/, IMapper mapper, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register([FromBody] UserDTo dto)
        {
            _logger.LogInformation(dto.Email);
            var validation = new UserDTOValidation();
            var validationResult = await validation.ValidateAsync(dto);
            if (validationResult.IsValid == false)
            {
                _logger.LogInformation($"Validation for {dto} failed !!!");
                return Problem();
            }

            try
            {
                var user = _mapper.Map<ApiUser>(dto);
                user.UserName = dto.Email;
                if (user == null)
                {
                    _logger.LogError("There is a Problem For Mapping ");
                    return BadRequest(StatusCode(500));
                }

                var creation = await _userManager.CreateAsync(user,dto.Password);
                if (!creation.Succeeded)
                {
                    _logger.LogError("There is a Problem In creating Process !!");
                    return BadRequest(StatusCode(500));
                }

                await _userManager.AddToRolesAsync(user, dto.Roles);
                return Ok(StatusCode(200));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong With {Register(dto)}");
                return StatusCode(500, "the Error Occurred During This process , Please Try later ");
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult> Login([FromBody] LoginDTO dto)
        //{
        //    var validation = new LoginDToValidation();
        //    var validationResult=await validation.ValidateAsync(dto);
        //    if (validationResult.IsValid==false)
        //    {
        //        _logger.LogInformation($"Validation for {dto} failed !!!");
        //        return Problem(statusCode:500);
        //    }

        //    try
        //    {
        //        var login = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);
        //        if (!login.Succeeded)
        //        {
        //            _logger.LogError("There is a Problem In logging Process !!");
        //            return Problem(statusCode:500);
        //        }

        //        return Ok(200);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Something Went Wrong With {Login(dto)}");
        //        return StatusCode(500, "the Error Occurred During This process , Please Try later ");
        //    }
        //}
    }
}
