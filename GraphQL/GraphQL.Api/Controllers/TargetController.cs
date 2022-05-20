using GraphQL.Application.Interfaces;
using GraphQL.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GraphQL.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TargetController : ControllerBase
    {
        private readonly ITargetService _targetService;

        public TargetController(ITargetService targetService)
        {
            _targetService = targetService;
        }

        /// <summary>
        /// Create call history and return match based on target
        /// </summary>
        /// <param name="combination">
        /// Contains a list of integers and an integer to be reached
        /// </param>
        /// <returns></returns>
        /// <response code="200">Combination performed</response>
        [HttpPost]
        [Route("create-combination")]
        public async Task<IActionResult> Create([FromBody] CombinationViewModel combination)
        {
            try
            {
                var resp = await _targetService.ProcessCombinationAsync(combination);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get combination history
        /// </summary>
        /// <param name="start">
        /// Initial date
        /// </param>
        /// <param name="end">
        /// Final date
        /// </param>
        /// <returns></returns>
        /// <response code="200">Obtained history</response>
        [HttpGet]
        [Route("history")]
        public IActionResult GetHistory(DateTime start, DateTime end)
        {
            try
            {
                var resp = _targetService.GetHistoryByDateRange(start, end);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
