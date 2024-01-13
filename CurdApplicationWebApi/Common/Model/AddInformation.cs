using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CurdApplicationWebApi.Common.Model
{
    public class AddInformationRequest
    {
        [Required]
        [NotNull]
        public string UserName {  get; set; }
        
        [Required]
        [NotNull]
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        [Required]
        [NotNull]
        [Phone]
        public string MobileNumber { get; set; }
        
        [Required]
        [NotNull]
        public string Gender { get; set; }
        
        [Required]
        [NotNull]
        public int Salary { get; set; }

    }

    public class AddInformationResponse
    {
        public bool IsSuccessfull {  get; set; }
        public string Message {  get; set; } 
    }
}
