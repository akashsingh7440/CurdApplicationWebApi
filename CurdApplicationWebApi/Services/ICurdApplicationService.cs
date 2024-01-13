using CurdApplicationWebApi.Common.Model;

namespace CurdApplicationWebApi.Services
{
    public interface ICurdApplicationService
    {
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);
        public Task<GetAllInformationResponse> GetAllInformation();
    }
}
