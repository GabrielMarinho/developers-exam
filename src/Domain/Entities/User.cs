using System.Text.RegularExpressions;
using FluentValidation;

namespace Domain.Entities;

public class User : Entity<User>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Login { get; private set; }
    public string Email { get; private set; }
    public int Age { get; private set; }

    private void DefineRules()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(255);
        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(255);
        RuleFor(x => x.Email)
            .NotEmpty()
            .Matches(@"^\w+([+\.-]?\w+)*@\w+([_\.-]?\w+)*(\.\w+)$", RegexOptions.IgnoreCase)
            .MaximumLength(255);
        RuleFor(x => x.Login)
            .NotEmpty();
        RuleFor(x => x.Age)
            .InclusiveBetween(10, 100);
    }

    public User(string firstName, string lastName, string login, string email, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Login = login;
        Email = email;
        Age = age;
        
        DefineRules();
    }
    
    public User(long id, string firstName, string lastName, string login, string email, int age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Login = login;
        Email = email;
        Age = age;
        
        DefineRules();
    }
    
    public override bool IsValid()
    {
        ValidationResult = Validate(this);
        return ValidationResult.IsValid;
    }
}