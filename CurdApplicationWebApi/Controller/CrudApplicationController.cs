using CurdApplicationWebApi.Common.Model;
using CurdApplicationWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CurdApplicationWebApi.Controller
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudApplicationController : ControllerBase
    {
        private readonly ICurdApplicationService _curdApplicationService;
        private readonly ILogger<CrudApplicationController> _logger;
        public CrudApplicationController(ICurdApplicationService curdApplicationService, ILogger<CrudApplicationController> logger)
        {
            _curdApplicationService = curdApplicationService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddInformation(AddInformationRequest request)
        {
            _logger.LogInformation($"Controler Layer....{JsonConvert.SerializeObject(request)}");
            var response = new AddInformationResponse();
            try
            {
                response = await _curdApplicationService.AddInformation(request);
                if (response.IsSuccessfull == false)
                {
                    return BadRequest(new { IsSuccessfull = response.IsSuccessfull, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessfull = false;
                response.Message = ex.Message;
                _logger.LogError($"Exception in Controller : {response.Message}");
                return BadRequest(new { IsSuccessfull = response.IsSuccessfull, Message = response.Message });
            }
            return Ok(new { IsSuccessfull = response.IsSuccessfull, Message = response.Message });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInformation()
        {
            _logger.LogInformation($"All Information Details in controller.....");
            var response = new UserInformationResponse();
            try
            {
                response = await _curdApplicationService.GetAllInformation();
                if (response.IsSuccessfull == false)
                {
                    return NotFound(new { IsSuccessfull = response.IsSuccessfull, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessfull = false;
                response.Message = ex.Message;
                _logger.LogError($"Exception in controller : {response.Message}");
                return NotFound(new { Success = response.IsSuccessfull, Message = response.Message });
            }
            return Ok(response.Result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetInformationById(int userId)
        {
            var response = new UserInformationDetailResponse();
            try
            {
                response = await _curdApplicationService.GetUserInformation(userId);
                if (response.Success == false)
                {
                    return NotFound(new { IsSuccessfull = response.Success, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                _logger.LogError($"Exception in GetInformationById Controller : {response.Message}");

            }
            return Ok(response.Result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInformation(UpdateInformationRequest request)
        {
            var response = new UpdateInformationResponse();
            try
            {
                response = await _curdApplicationService.UpdateUserInformation(request);
                if (response.IsSuccessfull == false)
                {
                    return BadRequest(new { IsSuccessfull = response.IsSuccessfull, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessfull = false;
                response.Message = ex.Message;
            }
            return Ok(response.Result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInformationById(int id)
        {
            var response = new DeleteInformationByIdResponse();
            try
            {
                response = await _curdApplicationService.DeleteUserInformationById(id);
                if(response.IsSuccessfull == false)
                {
                    return BadRequest(new {IsSuccessfull = response.IsSuccessfull,Message = response.Message});
                }
            }
            catch(Exception ex)
            {
                response.IsSuccessfull = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDeleteUserInformation()
        {
            var response = new UserInformationResponse();
            try
            {
                response = await _curdApplicationService.GetAllDeleteUserInformation();
                if(response.IsSuccessfull == false)
                {
                    return BadRequest(new {IsSuccessfull = response.IsSuccessfull, Message = response.Message});
                }
            }
            catch(Exception ex)
            {
                response.IsSuccessfull = false;
                response.Message = ex.Message;
            }
            return Ok(response.Result);
        }

    }
}
