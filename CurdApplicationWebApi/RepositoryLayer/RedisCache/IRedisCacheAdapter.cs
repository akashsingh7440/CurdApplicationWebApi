using CurdApplicationWebApi.Common.Model;

namespace CurdApplicationWebApi.RepositoryLayer
{
    public interface IRedisCacheAdapter
    {
        public Task<AddInformationResponse> AddInformation(UserInformationDetailResponse request);
        public Task<UserInformationDetailResponse> GetUserInformation(int userId);
        public Task<DeleteAllDeactivatedInformation> DeleteAllDeactivatedInformation();
    }
}
