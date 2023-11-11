using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace TaskTeamWork.ViewModels.Account;

public class MainViewModel
{
    public RegisterViewModel RegisterView { get; set; }

    public LoginViewModel LoginView { get; set; }

    public MainViewModel()
    {
        RegisterView = new RegisterViewModel();
        LoginView = new LoginViewModel();
    }
}
