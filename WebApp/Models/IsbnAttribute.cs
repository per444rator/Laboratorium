using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApp.Models;

public class IsbnAttribute : ValidationAttribute
{
    public bool RequireChecksum { get; set; } = false;

    public IsbnAttribute() => ErrorMessage = "Nieprawidłowy format ISBN";

    public override bool IsValid(object? value)
    {
        if (value is not string isbn) return true; 

        var cleanIsbn = isbn.Replace("-", "").Replace(" ", "");
        if (cleanIsbn.Length != 10 && cleanIsbn.Length != 13) return false;
        
       
        if (RequireChecksum && cleanIsbn.Length == 13 && Regex.IsMatch(cleanIsbn, @"^\d{13}$"))
        {
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += (cleanIsbn[i] - '0') * (i % 2 == 0 ? 1 : 3);
            }
            int checkDigit = cleanIsbn[12] - '0';
            int calculatedCheck = (10 - (sum % 10)) % 10;
            return checkDigit == calculatedCheck;
        }
        return true;
    }
}