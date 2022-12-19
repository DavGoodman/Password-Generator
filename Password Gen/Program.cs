using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isValid = true;
            int passwordLength = 0;
            string pattern = args[1];
            string result = "";

            // checks if args[0] is only digits or exists
            try
            {
                isValid = int.TryParse(args[0], out passwordLength);
            }
            catch(Exception)
            {
                isValid = false;
            }

            // checks if args[1] has valid letters
            foreach(char c in args[1])
            {    
                if (c != 'l' && c != 'L' && c != 'd' && c != 's') 
                {
                    isValid = false;
                }
            }

            if (!isValid || passwordLength != pattern.Length) 
            {
                ShowHelpText();
                return;
            }



            while (pattern.Length > 0)
            {
                var random = new Random();
                int randCharIndex = random.Next(0, pattern.Length - 1);

                switch (pattern[randCharIndex])
                {
                    case 'l':
                        result += WriteRandomLowerCaseLetter();
                        break;
                    case 'L':
                        result += WriteRandomUpperCaseLetter();
                        break;
                    case 'd':
                        result += WriteRandomDigit(); 
                        break;
                    case 's':
                        result += WriteRandomSpecialCharacter();
                        break;                 
                }

                pattern = pattern.Remove(randCharIndex, 1);
            }


            Console.WriteLine(result);

        }

        static public char WriteRandomLowerCaseLetter()
        {
            var random = new Random();
            return (char)random.Next(97, 122);
        }

        static public char WriteRandomUpperCaseLetter()
        {
            var random = new Random();
            return (char)random.Next(65, 90);
        }

        static public string WriteRandomDigit()
        {
            var random = new Random();
            return random.Next(0, 9).ToString(); // get num between 0 and 9
        }

        static public char WriteRandomSpecialCharacter()
        {
            string allSpecialChars = "!#$%&()*+-/_";
            int specialsLength = allSpecialChars.Length;
            var random = new Random();
            return allSpecialChars[random.Next(0, specialsLength)];
        }



        static public void ShowHelpText()
        {
            Console.WriteLine("PasswordGenerator  \r\n  Options:\r\n  - l = lower case letter\r\n  - L = upper case letter\r\n  - d = digit\r\n  - s = special character (!\"#¤%&/(){}[]\r\nExample: PasswordGenerator 14 lLssdd\r\n         Min. 1 lower case\r\n         Min. 1 upper case\r\n         Min. 2 special characters\r\n         Min. 2 digits");
        }
    }
}