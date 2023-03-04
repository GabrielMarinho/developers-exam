using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum ErrorCode
{
    [Display(Name = "USER-NOT-AVAILABLE")]
    [Description("First/Last name or Email/Login is not available")]
    UserNotAvailable,
    
    [Display(Name = "USER-NOT-FOUND")]
    [Description("User not found!")]
    UserNotFound
}