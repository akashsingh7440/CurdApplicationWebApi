using CurdApplicationWebApi.Common.Model;
using CurdApplicationWebApi.RepositoryLayer;
using CurdApplicationWebApi.Services;

namespace CurdApplicationWebApi.Component
{
    public class CurdApplicationComponent : ICurdApplicationComponent
    {
        public readonly ICurdApplicationService _curdApplicationService;
        public readonly IRedisCacheAdapter _redisCacheAdapter;
        public CurdApplicationComponent(ICurdApplicationService curdApplicationService, IRedisCacheAdapter redisCacheAdapter)
        {
            _curdApplicationService = curdApplicationService;
            _redisCacheAdapter = redisCacheAdapter;
        }
        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            var response = await _curdApplicationService.AddInformation(request);
            return response;
        }

        public async Task<DeleteAllDeactivatedInformation> DeleteAllDeactivatedInformation()
        {
            var response = await _curdApplicationService.DeleteAllDeactivatedInformation();
            return response;
        }

        public async Task<DeleteInformationByIdResponse> DeleteUserInformationById(int id)
        {
            var response = await _curdApplicationService.DeleteUserInformationById(id);
            return response;
        }

        public async Task<UserInformationResponse> GetAllDeleteUserInformation()
        {

            var response = await _curdApplicationService.GetAllDeleteUserInformation();
            return response;
        }
        public Task<UserInformationDetailResponse> GetUserInformation(int userId)
        {
            
            var response = _curdApplicationService.GetUserInformation(userId);
            return response;
        }
        public async Task<UserInformationResponse> GetAllInformation()
        {
            var response = await _curdApplicationService.GetAllInformation();
            return response;
        }
        public Task<UpdateInformationResponse> UpdateUserInformation(UpdateInformationRequest request)
        {
            var response = _curdApplicationService?.UpdateUserInformation(request);
            return response;
        }
    }
}
