namespace CurdApplicationWebApi.Common.Model
{
    public class UserInformationDetailResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public UserInformation Result { get; set; }
    }

}
