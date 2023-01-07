using ARS_OS.Business;
using ARS_OS.Models;
using ARS_OS.Models.ApiModels;
using ARS_OS.Models.FilterModels;
using ARS_OS.Models.InputModels;
using ARS_OS.Models.OutputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ARS_OS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TripPlanController : ControllerBase
    {
        private readonly ITripPlanBusiness _tripPlanBusiness;
        private readonly ILogger<TripPlanController> _logger;


        public TripPlanController(ILogger<TripPlanController> logger, ITripPlanBusiness tripPlanBusiness)
        {
            _logger = logger;
            _tripPlanBusiness = tripPlanBusiness;
        }


        [HttpGet]
        public async Task<ApiResponse<ApiList<IList<TripPlanOutput>>>> GetList([FromQuery] Filter filter) => 
            await _tripPlanBusiness.GetAll("customerId", filter);

        [HttpPost]
        public async Task<ApiResponse<TripPlanOutput>> Insert(TripPlanInput input) =>
            await _tripPlanBusiness.Insert("customerId", input);

        [HttpPatch]
        public async Task<ApiResponse<bool>> UpdatePublishStatus(TripPlanPublishInput input) =>
           await _tripPlanBusiness.Update("customerId", input);

        [HttpPost]
        [Route("request")]
        public async Task<ApiResponse<bool>> AttendRequest(TripPlanRequestInput input) =>
            await _tripPlanBusiness.AttendRequest("customerId", input);
    }
}