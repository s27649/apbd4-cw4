using System;

namespace LegacyApp;

public class Valid
{
    public static bool EmailValid(string email)
    {
        return !email.Contains("@") && !email.Contains(".");
    }

    public static bool NameValid(string firstName, string lastName)
    {
        return string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName);
    }
    public static bool AgeValid(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        return age < 21;
    }

    public static bool AllValid(string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        if (Valid.NameValid(firstName, lastName))
            return false;
        if (Valid.EmailValid(email))
            return false;
        if (Valid.AgeValid(dateOfBirth))
            return false;
        return true;
    }

    public static bool UserServiseValid(User user)
    {
        return user.HasCreditLimit && user.CreditLimit < 500;
    }
    
}