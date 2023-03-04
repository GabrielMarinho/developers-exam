using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Domain.Extensions;

public static class EnumExtension
{
    public static string GetDescription(this Enum value) => value?
                                                                .GetType()
                                                                    .GetMember(value.ToString())
                                                                    .FirstOrDefault()
                                                                    ?.GetCustomAttribute<DescriptionAttribute>()
                                                                    ?.Description
                                                                ?? value.ToString();
    
    public static string GetDiaplay(this Enum value) => value?
                                                                .GetType()
                                                                .GetMember(value.ToString())
                                                                .FirstOrDefault()
                                                                ?.GetCustomAttribute<DisplayAttribute>()
                                                                ?.Description
                                                            ?? value.ToString();
}