using System;

namespace Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
         char[] password = Console.ReadLine().ToLower().ToCharArray();
           
            lenghtChecker(password);
            lettersAndDigitsChecker(password);
            twoDigitsTest(password);
            if (lenghtChecker(password) == false && lettersAndDigitsChecker(password) == false && twoDigitsTest(password) == false)
            {
                Console.WriteLine("Password is valid");
            }
        }
        static bool lenghtChecker(char[] password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return true;
            }
            else
            {
             
            }
            return false;
        }
        static bool lettersAndDigitsChecker(char[] password) 
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 || password[i] <= 58 || password[i] >= 65 || password[i] <= 90 || password[i]>= 97 || password[i]>=122)
                {
                    
                }
                else
                {
                 Console.WriteLine("Password must consist only of letters and digits");
                    return true;
                }
                
            }
            return false;
        }
        static bool twoDigitsTest(char[] password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] < 48 && password[i] > 57)
                {
                    counter++;
                }
            }
            if (counter !>= 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                return true;
            }
            return false;
        }
        
    }
}
