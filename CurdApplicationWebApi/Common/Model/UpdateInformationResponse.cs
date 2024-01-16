using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CurdApplicationWebApi.Common.Model
{
    public class UpdateInformationResponse
    {
        public bool IsSuccessfull { get; set; }
        public string Message { get; set; }

        public UpdateInformationRequest Result { get; set; }

    }

    public class UpdateInformationRequest
    {
        [Required]
        [NotNull]
        public int UserId { get; set; }
        [Required]
        [NotNull]
        public string UserName { get; set; }

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
}
