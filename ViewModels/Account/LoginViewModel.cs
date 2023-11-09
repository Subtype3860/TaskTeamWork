namespace TaskTeamWork.ViewModels.Account;

public class LoginViewModel
{
    public string? Password { get; set; }
    public bool RememberMe { get; set; }
    public string? ReturnUrl { get; set; }
}