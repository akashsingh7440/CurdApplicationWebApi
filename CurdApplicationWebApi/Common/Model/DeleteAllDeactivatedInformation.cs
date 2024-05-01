namespace CurdApplicationWebApi.Common.Model
{
    public class DeleteAllDeactivatedInformation
    {
        public bool IsSuccessfull { get; set; }
        public string Message { get; set; }
        public int DeletedItemCount { get; set; }
    }
}
