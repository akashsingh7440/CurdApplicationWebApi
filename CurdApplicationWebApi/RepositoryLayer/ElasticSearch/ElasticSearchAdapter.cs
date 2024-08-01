using CurdApplicationWebApi.Common.Model;

namespace CurdApplicationWebApi.RepositoryLayer
{
    public class ElasticSearchAdapter : IDatabaseAdapter
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ElasticSearchAdapter> _logger;
        public ElasticSearchAdapter(IConfiguration configuration, ILogger<ElasticSearchAdapter> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteAllDeactivatedInformation> DeleteAllDeactivatedInformation()
        {
            throw new NotImplementedException();
        }

        public Task<DeleteInformationByIdResponse> DeleteUserInformationById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationResponse> GetAllDeleteUserInformation()
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationResponse> GetAllInformation()
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationDetailResponse> GetUserInformation(int username)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateInformationResponse> UpdateUserInformation(UpdateInformationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
