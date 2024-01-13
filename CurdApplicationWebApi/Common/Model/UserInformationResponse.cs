namespace CurdApplicationWebApi.Common.Model
{
    public class UserInformationResponse
    {
        public bool IsSuccessfull { get; set; }
        public string Message { get; set; }

        public List<UserInformation> Result { get; set; }

    }
    public class UserInformation
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public long Salary { get; set; }
        public string Gender { get; set; }
        public int IsActive { get; set; }

    }
}
