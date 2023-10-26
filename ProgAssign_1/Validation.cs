using System;
using System.Text.RegularExpressions;

namespace ProgAssign1
{
    public class Validation
    {
        public static bool Validate(DataAttributes record)
        {

            if (string.IsNullOrWhiteSpace(record.FirstName) || !Regex.IsMatch(record.FirstName, "^[A-Za-z]+$"))
            {
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(record.LastName) || !Regex.IsMatch(record.LastName, "^[A-Za-z]+$"))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(record.StreetNumber) || !Regex.IsMatch(record.StreetNumber, "^[0-9]+$"))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(record.Street) || !Regex.IsMatch(record.Street, @"^[A-Za-z\s]+$"))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(record.City) || !Regex.IsMatch(record.City, "^[A-Za-z]+$"))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(record.Province) || !Regex.IsMatch(record.Province, "^[A-Za-z\\s]+$"))
            {
                return false;
            }

            if (!Regex.IsMatch(record.PostalCode, @"^[A-Za-z0-9]{3} [A-Za-z0-9]{3}$"))
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(record.Country) && !Regex.IsMatch(record.Country, "^[A-Za-z]+$"))
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(record.PhoneNumber) && !Regex.IsMatch(record.PhoneNumber, @"^\d{10}$"))
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(record.EmailAddress) && !Regex.IsMatch(record.EmailAddress, @"^[\w\.-]+@[\w\.-]+\.\w+$"))
            {
                return false;
            }
            return true;
        }
    }
}

