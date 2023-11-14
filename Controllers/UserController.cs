using Ecc.Models;
using Ecc.Repositories.Interfaces;
using Ecc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Ecc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly PasswordHashService _passwordHasher;

        public UserController(IUserRepository userRepository, PasswordHashService passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }


        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid || userModel == null)
            {
                return BadRequest("Invalid user data. Make sure to fill in all the required fields.");
            }

            if (!IsEmailValid(userModel.Email!))
            {
                return BadRequest("Invalid email address.");
            }

            var user = await _userRepository.CreateUserAsync(userModel);
            if (user == null)
            {
                return Conflict("Error while creating user.");
            }

            return Ok(user);

        }


        [HttpGet("getusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server internal error tony. " + ex.Message);
            }
        }


        [HttpGet("getuserbyemail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest("O e-mail não pode ser nulo ou vazio.");
                }

                var user = await _userRepository.GetUserByEmail(email);

                if (user == null)
                {
                    return NotFound($"Usuário com o e-mail '{email}' não encontrado.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("updateuser/{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UserModel updatedUser)
        {
            try
            {
                if (userId == Guid.Empty)
                {
                    return BadRequest("Email cannot be empty or null");
                }

                var user = await _userRepository.UpdateUserAsync(userId, updatedUser);

                if (user == null)
                {
                    return NotFound($"User with the email: {userId}' wasn't found.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteuser/{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
           try{
            var success = await _userRepository.DeleteUserAsync(userId);

            if(!success)
            {
                return NotFound($"User with the {userId} wasn't found");
            }
            return Ok("User deleted");
           }
           catch(Exception ex)
           {
            return StatusCode(500, $"Internal server error: {ex.Message}");
           }
        
        }

        private bool IsEmailValid(string email)
        {
            try
            {
                var emailRegex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
                return emailRegex.IsMatch(email);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }



}


