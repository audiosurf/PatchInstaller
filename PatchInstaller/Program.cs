// See https://aka.ms/new-console-template for more information

using Microsoft.Win32;
using System.IO.Compression;

string Location = "";

Console.Title = "Audiosurf 2 Community Patch Installer";

Console.WriteLine("First we need the directory where Audiosurf 2 is installed");
Console.WriteLine("----------");
Console.WriteLine("Your options are");
Console.WriteLine("1) AutoFind the Directory");
Console.WriteLine("2) Enter the location yourself");
Console.WriteLine("----------");
Console.WriteLine("Make your selection (1 or 2) and hit Enter");
var selected = Console.ReadLine();
if (string.IsNullOrEmpty(selected) || !(selected == "1" || selected == "2"))
{
    Console.WriteLine("Invalid selection, exiting...");
    return;
}
else if (selected == "1")
{
    if (Directory.Exists("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Audiosurf 2"))
    {
        Location = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Audiosurf 2";
    }
    else
    {
        try
        {
            //GameID: 235800
            object? steamPath = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Valve\\Steam", "InstallPath", null);
            if (steamPath == null)
                return;
            var vdfText = await File.ReadAllLinesAsync(Path.Combine(steamPath.ToString() ?? throw new InvalidOperationException(), "config\\libraryfolders.vdf"));
            var gameLineText = vdfText.FirstOrDefault(x => x.Contains("\"235800\"")) ?? throw new DirectoryNotFoundException();
            var lineIndex = Array.IndexOf(vdfText, gameLineText);
            for (int i = lineIndex - 1; i >= 0; i--)
            {
                if (vdfText[i].Contains("\"path\""))
                {
                    vdfText[i] = vdfText[i].Replace("\"path\"", "");
                    var libraryPath = vdfText[i][(vdfText[i].IndexOf('\"') + 1) .. vdfText[i].LastIndexOf('\"')];
                    libraryPath = libraryPath.Replace("\\\\", "\\");
                    Location = Path.Combine(libraryPath, "steamapps\\common\\Audiosurf 2");
                    break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Unable to find game location, exiting...");
            return;
        }
    }
}
else if (selected == "2")
{
    Console.WriteLine("Please enter the path");
    var path = Console.ReadLine();
    if (Directory.Exists(path))
    {
        if(Directory.GetFiles(path).Any(x => x.Contains("Audiosurf2.exe")))
        {
            Location = path;
        }
        else
        {
            Console.WriteLine("Audiosurf2.exe not found, exiting...");
            return;
        }
    }
    else
    {
        Console.WriteLine("Directory doesnt exist, exiting...");
        return;
    }
}
Console.WriteLine("Ready to install in path:");
Console.WriteLine(Location);
Console.WriteLine("Press Enter to install");
Console.ReadLine();
var client = new HttpClient();
Console.WriteLine("Downloading files...");
var latest = await client.GetStreamAsync("https://aiae.ovh/brownie/audiosurf2_updater.zip");
var archive = new ZipArchive(latest);
Console.WriteLine("Extracting files...");
archive.ExtractToDirectory(Location, true);
Console.WriteLine("Installation complete, have fun :)");
Console.ReadLine();