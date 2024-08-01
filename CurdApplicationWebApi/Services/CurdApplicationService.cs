using CurdApplicationWebApi.Common.Model;
using CurdApplicationWebApi.RepositoryLayer;
using StackExchange.Redis;

namespace CurdApplicationWebApi.Services
{
    public class CurdApplicationService : ICurdApplicationService
    {
        private readonly IDatabaseFactory _databaseAdaptorFactory;
        public readonly IRedisCacheAdapter _redisCacheAdapter;
        public readonly IDatabaseAdapter _databaseClient;
        public readonly IConfiguration _configuration;
        public readonly bool _isCacheEnable;
        public CurdApplicationService(IDatabaseFactory databaseAdaptorFactory, IRedisCacheAdapter redisCacheAdapter, IConfiguration configuration)
        {
            _databaseAdaptorFactory = databaseAdaptorFactory;
            _redisCacheAdapter = redisCacheAdapter;
            _isCacheEnable = configuration.GetValue<bool>("IsCacheEnable");
            _databaseClient = _databaseAdaptorFactory.GetDatabase();
        }

        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            var response = await _databaseClient.AddInformation(request);
            return response;
        }

        public async Task<DeleteAllDeactivatedInformation> DeleteAllDeactivatedInformation()
        {
            var response = await _databaseClient.DeleteAllDeactivatedInformation();
            return response;
        }

        public async Task<DeleteInformationByIdResponse> DeleteUserInformationById(int id)
        {
     
            var response = await _databaseClient.DeleteUserInformationById(id);
            return response;
        }

        public async Task<UserInformationResponse> GetAllDeleteUserInformation()
        {
            var response = await _databaseClient.GetAllDeleteUserInformation();
            return response;
        }

        public async Task<UserInformationResponse> GetAllInformation()
        {
            var response = await _databaseClient.GetAllInformation();
            return response;
        }

        public Task<UserInformationDetailResponse> GetUserInformation(int userId)
        {
            if (_isCacheEnable)
            {
                var cacheResponce = _redisCacheAdapter.GetUserInformation(userId);
                if (cacheResponce != null && cacheResponce.Result != null)
                {
                    return cacheResponce;
                }
            }
            var response = _databaseClient.GetUserInformation(userId);
            _redisCacheAdapter.AddInformation(response.Result);
            return response;
        }

        public Task<UpdateInformationResponse> UpdateUserInformation(UpdateInformationRequest request)
        {
            var response = _databaseClient?.UpdateUserInformation(request);
            return response;
        }
    }
}
