using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WeVote.Constants;
using WeVote.Dtos;
using WeVote.Exceptions;
using WeVote.Services;

namespace WeVote.Controllers
{
    [Route("api/visit")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly ILogger<VisitController> _logger;
        private readonly IVisitService _service;

        public VisitController(ILogger<VisitController> logger, IVisitService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("")]
        public async Task<ActionResult<ApiResponseDto<bool>>> createVisit([FromBody] CreateVisitDto visit)
        {
            ApiResponseDto<bool> _response = new ApiResponseDto<bool>();
            try
            {
                bool isSucess = await _service.CreateVisit(visit);

                _response.Result = true;
                _response.Message = APIMessages.OK;
                _response.Errors = new List<string>();
                _response.IsSuccess = isSucess;
                _response.Code = HttpStatusCode.OK;
                return Ok(_response);

            } catch (Exception ex)
            {
                _response.Result = false;
                _response.IsSuccess = false;
                _response.Code = HttpStatusCode.InternalServerError;
                _response.Message = APIMessages.ServerError;
                return new ObjectResult(_response)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
