using CurdApplicationWebApi.Common.Model;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text;

namespace CurdApplicationWebApi.RepositoryLayer
{
    public class RedisCacheAdapter : IRedisCacheAdapter
    {
        public readonly IDatabase _redisDB;
        public RedisCacheAdapter() 
        {
            string redisConnectionString = "localhost:6379";
            // Create a connection to Redis
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnectionString);
            _redisDB = redis.GetDatabase();
        }
        public async Task<AddInformationResponse> AddInformation(UserInformationDetailResponse request)
        {
            var response = new AddInformationResponse();
            var key = request.Result.UserId.ToString();
            var value = JsonConvert.SerializeObject(request.Result);
            response.IsSuccessfull  = _redisDB.StringSet(key, value);
            return response;
        }

        public Task<DeleteAllDeactivatedInformation> DeleteAllDeactivatedInformation()
        {
            throw new NotImplementedException();
        }

        public async Task<UserInformationDetailResponse> GetUserInformation(int userId)
        {
            var responseByte =  _redisDB.StringGet(userId.ToString());
            var userInformation = new UserInformationDetailResponse();
            userInformation.Success = true;

            if(!responseByte.IsNullOrEmpty)
            {
                userInformation.Result = JsonConvert.DeserializeObject<UserInformation>(responseByte);
            }
            
            return userInformation;
        }
    }
}
