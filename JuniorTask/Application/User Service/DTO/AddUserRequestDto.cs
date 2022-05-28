using System.ComponentModel.DataAnnotations;

namespace JuniorTask.Application.User_Service.DTO
{
    public record AddUserRequestDto(
        [Required] string Name,
        [Required] string LastName,
        [Required] string PersonalNumber,
        [Required] int GenderId,
        [Required] bool Status,
        DateTime BirthDate = default);

}
