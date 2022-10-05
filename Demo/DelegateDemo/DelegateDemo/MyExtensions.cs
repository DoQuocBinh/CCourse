using System;
namespace DelegateDemo
{
    public static class MyExtensions
    {
        public static bool isValidEmail(this String email)
        {
            
            return email.Contains("@") && (email.Length > 5);
        }
        public static bool isInRange10_100(this int number)
        {
            return number >= 10 && number <= 100;
        }
        public static bool isFriday(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Friday;
        }
    }
}

