namespace CurdApplicationWebApi.Utility
{
    public static class SqlQuries
    {
        public static IConfiguration _configuration = new ConfigurationBuilder().AddXmlFile("SqlQuries.xml",true,true).Build();
        public static string AddInformation { get { return _configuration["AddInformation"]; } }
        public static string GetAllInformation { get { return _configuration["GetAllInformation"]; } }
        public static string GetUserInformationById { get { return _configuration["GetUserInformationById"]; } }
    }
}
