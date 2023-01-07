using ARS_OS.Data;
using ARS_OS.Managers;
using ARS_OS.Models;
using ARS_OS.Models.ApiModels;
using ARS_OS.Models.FilterModels;
using ARS_OS.Models.InputModels;
using ARS_OS.Models.OutputModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ARS_OS.Business
{
    public interface ITripPlanBusiness
    {
        Task<ApiResponse<ApiList<IList<TripPlanOutput>>>> GetAll(string customerId, Filter filter);
        Task<ApiResponse<TripPlanOutput>> Insert(string customerId, TripPlanInput input);
        Task<ApiResponse<bool>> Update(string customerId, TripPlanPublishInput input);
        Task<ApiResponse<bool>> AttendRequest(string customerId, TripPlanRequestInput input);
    }

    public class TripPlanBusiness : ITripPlanBusiness
    {
        private readonly AdessoRideShareDbContext _dbContext;
        private readonly IHelperManager _helperManager;
        private readonly IMapper _mapper;

        public TripPlanBusiness(
            IMapper mapper,
            AdessoRideShareDbContext dbContext,
            IHelperManager helperManager
            )
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _helperManager = helperManager;
        }

        public async Task<ApiResponse<ApiList<IList<TripPlanOutput>>>> GetAll(string customerId, Filter filter)
        {
            if(filter.From == null || filter.To == null)
            {
                return new ApiResponse<ApiList<IList<TripPlanOutput>>>(null, false, 403, "Invalid Destinations");
            }
            var response = await _dbContext.TripPlans.Where(x => x.Published && x.FromCityId == filter.From && x.ToCityId == filter.To).OrderBy(x => x.DatePlanned).ToListAsync();

            var apiList = new ApiList<IList<TripPlanOutput>>(_mapper.Map<List<TripPlanOutput>>(response), response.Count,
                response.Count);

            return new ApiResponse<ApiList<IList<TripPlanOutput>>>(apiList);
        }

        public async Task<ApiResponse<TripPlanOutput>> Insert(string customerId, TripPlanInput input)
        {
            var model = _mapper.Map<TripPlan>(input);
            model.CreateUserIP = _helperManager.GetRequestIp();
            model.CreateUserId = "createUserId";
            model.Id = Guid.NewGuid();
            model.Published = true;
            model.CreateTime = DateTime.UtcNow;
            model.IsDeleted = false;

            try
            {
                var response = await _dbContext.TripPlans.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return new ApiResponse<TripPlanOutput>(_mapper.Map<TripPlanOutput>(response.Entity));
            }
            catch (Exception ex)
            {
                return new ApiResponse<TripPlanOutput>(null, false, 500, ex.Message);
            }
        }

        public async Task<ApiResponse<bool>> Update(string customerId, TripPlanPublishInput input)
        {
            var entity = await _dbContext.TripPlans.SingleOrDefaultAsync(x => x.Id == input.Id);

            if (entity != null)
            {
                entity.Published = input.Published;
                entity.UpdateUserId = "updateUserId";
                entity.UpdateTime = DateTime.UtcNow;
                entity.UpdateUserIP = _helperManager.GetRequestIp();
                await _dbContext.SaveChangesAsync();
                return new ApiResponse<bool>(true);
            }
            return new ApiResponse<bool>(false, false, 400, "Not Found");
        }

        public async Task<ApiResponse<bool>> AttendRequest(string customerId, TripPlanRequestInput input)
        {
            var entity = await _dbContext.TripPlans.SingleOrDefaultAsync(x => x.Id == input.TripId);
            if(entity == null)
            {
                return new ApiResponse<bool>(false, false, 400, "Trip Not Found");
            }

            if(entity.NumberOfSeats < input.NumberOfSeats)
            {
                return new ApiResponse<bool>(false, false, 403, "Not enough seats");
            }

            try
            {
                var model = _mapper.Map<TripPlanRequest>(input);
                model.CreateUserIP = _helperManager.GetRequestIp();
                model.CreateUserId = "createUserId";
                model.Id = Guid.NewGuid();
                model.CreateTime = DateTime.UtcNow;
                model.IsDeleted = false;
                model.TripId = input.TripId;
                model.NumberOfSeats = input.NumberOfSeats;
                entity.NumberOfSeats = (short)(entity.NumberOfSeats - input.NumberOfSeats);
                var response = await _dbContext.TripPlanRequests.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return new ApiResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>(false, false, 500, ex.Message);
            }
        }
    }
}
