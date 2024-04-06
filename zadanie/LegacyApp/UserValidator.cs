using System;

namespace LegacyApp;

public class UserValidator
{
    private static bool AreNamesValid(string firstName, string lastName) => 
        !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName);

    private static bool IsEmailValid(string email) =>
        email.Contains("@") && email.Contains(".");

    private static bool IsUserOver21y(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        if (age < 21)
        {
            return false;
        }

        return true;
    }

    public bool ValidateUser(string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        if (!AreNamesValid(firstName, lastName))
            return false;

        if (!IsEmailValid(email))
        {
            return false;
        }

        if (!IsUserOver21y(dateOfBirth))
        {
            return false;
        }

        return true;
    }
}