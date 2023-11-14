namespace HospitalSystemAPI;

public class RegisterDto
{
    public string UserName   { get; set; } = string.Empty;
    public string Email      { get; set; } = string.Empty;
    public string Password   { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Role { get; set; } = "";
    public string Nationality { get; set; } = "";
}
