using System.ComponentModel.DataAnnotations;

namespace JuniorTask.Application.User_Service.DTO
{
    public record EditUserRequestDto([Required] string PersonalNumber, DateTime? BirthDate, bool? Status = null);
}
