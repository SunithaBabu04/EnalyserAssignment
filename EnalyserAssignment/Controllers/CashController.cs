using EnalyserAssignment.BAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EnalyserAssignment.Controllers
{
    [Route("Cash/")]
    [ApiController]
    public class CashController : ControllerBase
    {
        private readonly ICash _cash;

        public CashController(ICash cash)
        {
            _cash = cash;
        }

        /// <summary>
        /// Get all the notes details
        /// </summary>
        /// <returns>Notes list</returns>
        [HttpGet]
        [Route("GetAllNotes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllNotes()
        {
            CustomResponse response = new CustomResponse();
            try
            {
                response.Success = _cash.GetAllNotesDetails();
                response.response = "Success";
                return Ok(response);
            }
            catch(Exception ex)
            {
                response.response = "Error" + ex.Message.ToString();
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Get the cash details for the entered amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Cash Details</returns>
        [HttpGet]
        [Route("GetCash")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCash(int amount)
        {
            CustomResponse response = new CustomResponse();
            try
            {
                response.Success = _cash.GetCash(amount);
                response.response = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.response = "Error" + ex.Message.ToString();
                return BadRequest(response);
            }
        }
    }
}
