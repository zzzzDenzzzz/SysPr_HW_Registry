using Microsoft.Win32;
using System.Diagnostics;
using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        Registry.LocalMachine
            ?.OpenSubKey("SOFTWARE", true)
            ?.CreateSubKey("MyConsole")
            .SetValue("Background", ConsoleColor.Gray, RegistryValueKind.DWord);

        Registry.LocalMachine
            ?.OpenSubKey("SOFTWARE", true)
            ?.CreateSubKey("MyConsole")
            .SetValue("Foreground", ConsoleColor.Red, RegistryValueKind.DWord);

        var background = Registry.LocalMachine
            ?.OpenSubKey(@"SOFTWARE\MyConsole")
            ?.GetValue("Background");

        if (background != null)
        {
            Console.BackgroundColor = (ConsoleColor)background;
        }

        var foreground = Registry.LocalMachine
            ?.OpenSubKey(@"SOFTWARE\MyConsole")
            ?.GetValue("Foreground");

        if (foreground != null)
        {
            Console.ForegroundColor = (ConsoleColor)foreground;
        }

        Console.WriteLine("Hello!");
        Console.ResetColor();

        Environment.SetEnvironmentVariable("Path", Directory.GetCurrentDirectory(), EnvironmentVariableTarget.Machine);
    }
}