using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            CheckPass(pass);
        }
        static void CheckPass(string pass)
        {
            bool IsValid = true;
            if (pass.Length < 6 || pass.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                IsValid = false;
            }
            if (!CheckOnlyDiggitsAndLetters(pass))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                IsValid = false;
            }
            if (!CheckMoreThan2Digits(pass))
            {
                Console.WriteLine("Password must have at least 2 digits");
                IsValid = false;
            }
            if (IsValid)
            {
                Console.WriteLine("Password is valid");
            }


        }
        static bool CheckOnlyDiggitsAndLetters(string pass)
        {
            for (int i = 0; i < pass.Length; i++)
            {
                char currChar = pass[i];
                if (!((currChar >= 48 && currChar <= 57) || (currChar >= 65 && currChar <= 90) || (currChar>=97 && currChar<=122)))
                {
                    return false;
                }
            }
            return true;
        }
        static bool CheckMoreThan2Digits(string pass)
        {
            int count = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                string currDigit = pass[i].ToString();
                bool IsInt = int.TryParse(currDigit, out int a);
                if (IsInt)
                {
                    count++;
                }
            }
            if (count >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
