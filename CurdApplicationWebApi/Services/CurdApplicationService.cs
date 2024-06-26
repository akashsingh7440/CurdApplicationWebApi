﻿using CurdApplicationWebApi.Common.Model;
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

        public async Task<DeleteAllDeactivatedInformation> DeleteAllDeactivatedInformation()
        {
            var response = await _curdApplication.DeleteAllDeactivatedInformation();
            return response;
        }

        public async Task<DeleteInformationByIdResponse> DeleteUserInformationById(int id)
        {
            var response = await _curdApplication.DeleteUserInformationById(id);
            return response;
        }

        public async Task<UserInformationResponse> GetAllDeleteUserInformation()
        {
            var response = await _curdApplication.GetAllDeleteUserInformation();
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

        public Task<UpdateInformationResponse> UpdateUserInformation(UpdateInformationRequest request)
        {
            var response = _curdApplication?.UpdateUserInformation(request);
            return response;
        }
    }
}
