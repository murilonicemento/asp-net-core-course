using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "Email can't be blank")]
    [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password can't be blank")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}