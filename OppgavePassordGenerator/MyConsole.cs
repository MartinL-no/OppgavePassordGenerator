using System;

namespace OppgavePassordGenerator
{
    public class MyConsole
    {
        public static void ShowInputInstructions()
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
    }
}