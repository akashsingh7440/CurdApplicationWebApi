using CurdApplicationWebApi.Common.Model;

namespace CurdApplicationWebApi.RepositoryLayer
{
    public interface ICurdApplicationRepo
    {
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);
        public Task<UserInformationResponse> GetAllInformation();
        public Task<UserInformationDetailResponse> GetUserInformation(int username);
        public Task<UpdateInformationResponse> UpdateUserInformation(UpdateInformationRequest request);
        public Task<DeleteInformationByIdResponse> DeleteUserInformationById(int id);
        public Task<UserInformationResponse> GetAllDeleteUserInformation();
        public Task<DeleteAllDeactivatedInformation> DeleteAllDeactivatedInformation();

    }
}
