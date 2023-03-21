using System;

namespace OppgavePassordGenerator
{
    class Program
    {
        static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            if (!IsValid(args))
            {
                ShowHelpText();
                return;
            }

            int passwordLength = Convert.ToInt32(args[0]);
            string options = args[1];
            string pattern = passwordLength > options.Length
                ? options.PadRight(passwordLength, 'l')
                : options;
            
            while (pattern.Length > 0)
            {
                var randomIndex = Random.Next(0, pattern.Length);
                
                if (pattern[randomIndex] == 'l')
                {
                    WriteRandomLowerCaseLetter();
                }   
                else if (pattern[randomIndex] == 'L')
                {
                    WriteRandomUpperCaseLetter();
                }
                else if (pattern[randomIndex] == 'd')
                {
                    WriteRandomDigit();
                }
                else
                {
                    WriteRandomSpecialCharacter();
                }

                pattern = pattern.Substring(0, randomIndex) + pattern.Substring(randomIndex +1);
            }
        }

        private static bool IsValid(string[] args)
        {
            if (args.Length != 2)
            {
                return false;
            }
            else
            {
                if (DoesStringContainNonNumberCharacters(args[0]))
                {
                    return false;
                }
                else if (DoesOptionsStringIncludeInvalidCharacters(args[1]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool DoesStringContainNonNumberCharacters(string s)
        {
            foreach (var c in s)
            {
                if (!char.IsDigit(c))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool DoesOptionsStringIncludeInvalidCharacters(string s)
        {
            foreach (var c in s)
            {
                if (c != 'l' && c != 'L' && c != 'd' && c != 's')
                {
                    return true;
                }
            }

            return false;
        }

        private static void ShowHelpText()
        {
            Console.WriteLine(
                "PasswordGenerator\n" +
                "  Options:\n" +
                "  - l = lower case letter\n" +
                "  - L = upper case letter\n" +
                "  - d = digit\n" +
                "  - s = special character (!\"#¤%&/(){}[]\n" +
                "Example: PasswordGenerator 14 lLssdd\n" +
                "         Min. 1 lower case\n" +
                "         Min. 1 upper case\n" +
                "         Min. 2 special characters\n" +
                "         Min. 2 digits"
            );
        }

        private static void WriteRandomLowerCaseLetter()
        {
            Console.Write(GetRandomLetter('a','z'));
        }

        private static void WriteRandomUpperCaseLetter()
        {
            Console.Write(GetRandomLetter('A','Z'));
        }
        static char GetRandomLetter(char min, char max)
        {
            return (char)Random.Next(min, max + 1);
        }

        private static void WriteRandomDigit()
        {
            Console.Write(Random.Next(0,10));
        }

        private static void WriteRandomSpecialCharacter()
        {
            string specialCharacters = "(!\"#¤%&/(){}[]";
            var randomIndex = Random.Next(0, specialCharacters.Length);
            var randomSpecialCharacter = specialCharacters[randomIndex];
            
            Console.Write(randomSpecialCharacter);
        }
    }
}    
 
  
