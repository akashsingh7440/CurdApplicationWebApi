namespace CurdApplicationWebApi.Utility
{
    public static class SqlQuries
    {
        public static IConfiguration _configuration = new ConfigurationBuilder().AddXmlFile("SqlQuries.xml",true,true).Build();
        public static string AddInformation { get { return _configuration["AddInformation"]; } }
        public static string GetAllInformation { get { return _configuration["GetAllInformation"]; } }
        public static string GetUserInformationById { get { return _configuration["GetUserInformationById"]; } }
        public static string UpdateUserIngormationById { get { return _configuration["UpdateUserInformationById"]; } }
        public static string DeleteUserIngormationById { get { return _configuration["DeleteUserInformationById"]; } }
        public static string GetAllDeleteUserInformation { get { return _configuration["GetAllDeleteUserInformation"]; } }
    }
}
