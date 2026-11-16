using System;
using System.Data.SqlTypes;
using System.Globalization;
using ConsoleClient.Views;
using Core.Models;
using Core.Storage;

namespace ConsoleClient;

class Program
{
    static void Main()
    {
        MainConsoleView view = new MainConsoleView();
        view.Run();
    }
}