using CurdApplicationWebApi.Common.Model;
using CurdApplicationWebApi.RepositoryLayer;

namespace CurdApplicationWebApi.Services
{
    public class CurdApplicationService : ICurdApplicationService
    {
        private readonly ICurdApplicationRepo _curdApplication;
        public CurdApplicationService(ICurdApplicationRepo curdApplication)
        {
            _curdApplication = curdApplication;
        }

        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            var response = await _curdApplication.AddInformation(request);
            return response;
        }

        public async Task<UserInformationResponse> GetAllInformation()
        {
            var response = await _curdApplication.GetAllInformation();
            return response;
        }

        public Task<UserInformationDetailResponse> GetUserInformation(int username)
        {
            var response = _curdApplication.GetUserInformation(username);
            return response;
        }
    }
}
