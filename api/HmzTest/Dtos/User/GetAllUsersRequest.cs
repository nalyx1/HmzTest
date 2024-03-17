using System.ComponentModel.DataAnnotations;

namespace HmzTest.Dtos.User
{
    public class GetAllUsersRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "Page must be greater than 0.")]
        public int Page { get; set; } = 1;

        [Range(1, int.MaxValue, ErrorMessage = "PerPage must be greater than 0.")]
        public int PerPage { get; set; } = 10;
    }
}
