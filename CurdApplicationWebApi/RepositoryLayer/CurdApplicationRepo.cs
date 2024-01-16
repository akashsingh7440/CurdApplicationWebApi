using CurdApplicationWebApi.Common.Model;
using CurdApplicationWebApi.Utility;
using MySqlConnector;
using System.Reflection.Metadata.Ecma335;

namespace CurdApplicationWebApi.RepositoryLayer
{
    public class CurdApplicationRepo : ICurdApplicationRepo
    {
        public readonly IConfiguration _configuration;
        public MySqlConnection _mySqlConnection;
        private readonly ILogger<CurdApplicationRepo> _logger;
        public CurdApplicationRepo(IConfiguration configuration, ILogger<CurdApplicationRepo> logger)
        {
            _configuration = configuration;
            _mySqlConnection = new MySqlConnection(_configuration[key: "ConnectionStrings:MySqlDB"]);
            _logger = logger;

        }
        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {

            _logger.LogInformation($"Inside Repository Layer....");
            AddInformationResponse response = new AddInformationResponse();
            response.IsSuccessfull = true;
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                { 
                    await _mySqlConnection.OpenAsync();
                }
                using(MySqlCommand command = new MySqlCommand(SqlQuries.AddInformation, _mySqlConnection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 180;
                    command.Parameters.AddWithValue("@UserName", request.UserName);
                    command.Parameters.AddWithValue("@Email", request.EmailAddress);
                    command.Parameters.AddWithValue("@Mobile", request.MobileNumber);
                    command.Parameters.AddWithValue("@Gender", request.Gender);
                    command.Parameters.AddWithValue("@Salary", request.Salary);
                    var databaseResponse = await command.ExecuteNonQueryAsync();
                    if(databaseResponse <= 0)
                    {
                        response.IsSuccessfull = false;
                        response.Message = "Query not executed.";
                        _logger.LogError($"Error while executing Query....");
                    }
                }
            }
            catch(Exception ex)
            {
                response.IsSuccessfull = false;
                response.Message = ex.Message;
                _logger.LogInformation($"Exception in repository Layer {ex.Message}");
            }
            finally
            {
                await CloseAndDispposeDatabaseConnection();
            }
            return response;
        }

        public async Task<UserInformationResponse> GetAllInformation()
        {
            _logger.LogInformation($"Get All information from Database in Repository Layer...");
            UserInformationResponse response = new UserInformationResponse();
            response.IsSuccessfull = true;
            response.Result = new List<UserInformation>();

            if ( _mySqlConnection.State != System.Data.ConnectionState.Open )
            {
                _logger.LogInformation($"Trying to open Database Connection");
                await _mySqlConnection.OpenAsync();
            }
            try
            {
                using(MySqlCommand command = new MySqlCommand(SqlQuries.GetAllInformation, _mySqlConnection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 180;
                    command.Parameters.AddWithValue("IsActive", 1);

                    using(MySqlDataReader data = await command.ExecuteReaderAsync())
                    {
                        if(data.HasRows)
                        {
                            while (await data.ReadAsync())
                            {
                                UserInformation getData = new UserInformation();
                                getData.UserId = data["UserId"] != DBNull.Value ? Convert.ToInt16(data["UserId"]) : 0;
                                getData.UserName = Convert.ToString(data["UserName"]) ?? string.Empty; 
                                getData.Email = Convert.ToString(data["Email"]) ?? string.Empty;
                                getData.Mobile = Convert.ToInt64(data["Mobile"]);
                                getData.IsActive = Convert.ToInt32(data["IsActive"]);
                                getData.Gender = Convert.ToString(data["Gender"]) ?? string.Empty;
                                getData.Salary = Convert.ToInt64(data["Salary"]);

                                response.Result.Add(getData);
                            }
                        }
                        else
                        {
                            _logger.LogInformation($"Database dose not have any record..");
                        }
                        return response;
                    }

                }
            }
            catch(Exception ex)
            {
                response.IsSuccessfull = false;
                response.Message = ex.Message;
                return response;
            }
            finally
            {
                _logger.LogInformation($"Trying to Close connection and despose.");
                await CloseAndDispposeDatabaseConnection();
            }
        }

        public async Task<UserInformationDetailResponse> GetUserInformation(int userId)
        {
            var response = new UserInformationDetailResponse();
            response.Success = true;
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }
                using(MySqlCommand command = new MySqlCommand(SqlQuries.GetUserInformationById, _mySqlConnection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 180;
                    command.Parameters.AddWithValue("userId", userId);
                    command.Parameters.AddWithValue("IsActive", 1);

                    MySqlDataReader reader = await command.ExecuteReaderAsync();
                    UserInformation userData = new UserInformation();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            userData.UserId = reader["UserId"] != DBNull.Value ? Convert.ToInt32(reader["UserId"]) : 0;
                            userData.UserName = Convert.ToString(reader["UserName"]) ?? string.Empty;
                            userData.Email = Convert.ToString(reader["Email"]) ?? string.Empty;
                            userData.Gender = Convert.ToString(reader["Gender"]) ?? string.Empty;
                            userData.Salary = reader["UserId"] != DBNull.Value ? Convert.ToInt32(reader["Salary"]) : 0;
                            userData.Mobile = reader["UserId"] != DBNull.Value ? Convert.ToInt64(reader["Mobile"]) : 0;
                            userData.IsActive = reader["UserId"] != DBNull.Value ? Convert.ToInt32(reader["IsActive"]) : 0;
                        }
                    }
                    response.Result = userData;
                }
            }
            catch (Exception ex)
            {
                response.Success = false; 
                response.Message = ex.Message;
            }
            finally
            {
                await CloseAndDispposeDatabaseConnection();
            }
            return response;
        }

        public async Task<UpdateInformationResponse> UpdateUserInformation(UpdateInformationRequest request)
        {
            var response = new UpdateInformationResponse();
            response.IsSuccessfull = true;
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }
                using(MySqlCommand command = new MySqlCommand(SqlQuries.UpdateUserIngormationById, _mySqlConnection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 180;
                    
                    command.Parameters.AddWithValue("userId", request.UserId);
                    command.Parameters.AddWithValue("@UserName", request.UserName);
                    command.Parameters.AddWithValue("@Email", request.EmailAddress);
                    command.Parameters.AddWithValue("@Mobile", request.MobileNumber);
                    command.Parameters.AddWithValue("@Gender", request.Gender);
                    command.Parameters.AddWithValue("@Salary", request.Salary);

                    var Databaseresponse = await command.ExecuteNonQueryAsync();
                }
            }
            catch(Exception ex)
            {
                response.IsSuccessfull = false;
                response.Message = ex.Message;
            }
            finally
            {
                await CloseAndDispposeDatabaseConnection();
            }

            return response;
        }

        public async Task CloseAndDispposeDatabaseConnection()
        {
            await _mySqlConnection.CloseAsync();
            await _mySqlConnection.DisposeAsync();
        }

        public async Task<DeleteInformationByIdResponse> DeleteUserInformationById(int id)
        {
            var response = new DeleteInformationByIdResponse();
            response.IsSuccessfull = true;

            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }
                using(MySqlCommand command = new MySqlCommand(SqlQuries.DeleteUserIngormationById, _mySqlConnection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 180;

                    command.Parameters.AddWithValue("UserId", id);
                    var databaseResponse = await command.ExecuteNonQueryAsync();
                    if(Convert.ToBoolean(databaseResponse))
                    {
                        response.Message = "Successfully inactive this record.";
                    }
                }
            }
            catch(Exception ex)
            {
                response.IsSuccessfull = false;
                response.Message = ex.Message;
            }
            finally
            {
                await CloseAndDispposeDatabaseConnection();
            }
            return response;
        }

        public async Task<UserInformationResponse> GetAllDeleteUserInformation()
        {
            var response = new UserInformationResponse();
            response.IsSuccessfull = true;
            response.Result = new List<UserInformation>();
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }
                using( MySqlCommand command = new MySqlCommand(SqlQuries.GetAllDeleteUserInformation, _mySqlConnection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 180;
                    command.Parameters.AddWithValue("IsActive", 0);
                    var reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            UserInformation userInformation = new UserInformation();
                            userInformation.UserId = reader["UserId"] != DBNull.Value ? Convert.ToInt16(reader["UserId"]) : 0;
                            userInformation.UserName = Convert.ToString(reader["UserName"]) ?? string.Empty;
                            userInformation.Email = Convert.ToString(reader["Email"]) ?? string.Empty;
                            userInformation.Mobile = Convert.ToInt64(reader["Mobile"]);
                            userInformation.IsActive = Convert.ToInt32(reader["IsActive"]);
                            userInformation.Gender = Convert.ToString(reader["Gender"]) ?? string.Empty;
                            userInformation.Salary = Convert.ToInt64(reader["Salary"]);

                            response.Result.Add(userInformation);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                response.IsSuccessfull = false;
                response.Message = ex.Message;
            }
            finally
            {
                await CloseAndDispposeDatabaseConnection();
            }
            return response;
        }
    }
    
}
