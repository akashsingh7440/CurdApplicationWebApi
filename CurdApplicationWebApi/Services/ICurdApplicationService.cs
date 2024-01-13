using CurdApplicationWebApi.Common.Model;

namespace CurdApplicationWebApi.Services
{
    public interface ICurdApplicationService
    {
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);
        public Task<UserInformationResponse> GetAllInformation();
        public Task<UserInformationDetailResponse> GetUserInformation(int username);
    }
}
