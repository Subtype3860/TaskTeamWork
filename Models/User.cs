using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskTeamWork.Models;

public class User : IdentityUser
{
    [Required]
    [Display(Name ="Имя")]
    public string? FirstName { get; set; }
    [Required]
    [Display(Name = "Фамилия")]
    public string? LastName { get; set; }
    [Display(Name = "Отчество")]
    public string? MiddleName { get; set; }
    public DateTime BirthDate { get; set; }    
}