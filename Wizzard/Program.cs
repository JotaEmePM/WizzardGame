using System;

var args_data = Environment.GetCommandLineArgs();
var debug = false;

if (args_data != null)
{
    int idx = 0;
    foreach (var arg in args_data)
    {
        if (arg == "-d")
        {
            debug = Convert.ToBoolean(args_data[idx + 1]);
        }
        idx += 1;
    }
}
using var game = new Wizzard.Main(debug);
game.Run();
