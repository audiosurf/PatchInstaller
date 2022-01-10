// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Microsoft.Win32;
using System.IO.Compression;
using System.Runtime.InteropServices;

string location = "";

Console.Title = "Audiosurf 2 Community Patch Installer";

//Make compiler happy that we are indeed on a platform that can use Registry
if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    return;

#region Process Check

Console.Clear();
Console.WriteLine("Making Sure Audiosurf 2 isn't running...");
var procs = Process.GetProcessesByName("Audiosurf2");
if (procs.Length != 0)
{
    Console.WriteLine("Audiosurf 2 seems to be running, press Enter to stop it");
    Console.ReadLine();
    foreach (var process in procs)
    {
        process.Kill();
    }
}

#endregion

#region Directory Option Selection

Console.Clear();
Console.WriteLine("First we need the directory where Audiosurf 2 is installed");
Console.WriteLine("----------");
Console.WriteLine("Your options are");
Console.WriteLine("1) AutoFind the Directory");
Console.WriteLine("2) Enter the location yourself");
Console.WriteLine("----------");
Console.WriteLine("Make your selection (1 or 2) and hit Enter");
var selected = Console.ReadLine();

#endregion

#region Directory Operations/Validations

Console.Clear();
if (string.IsNullOrEmpty(selected) || !(selected == "1" || selected == "2"))
{
    Console.WriteLine("Invalid selection, exiting...");
    return;
}
else if (selected == "1")
{
    if (Directory.Exists("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Audiosurf 2"))
    {
        location = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Audiosurf 2";
    }
    else
    {
        try
        {
            //GameID: 235800
            object steamPath = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Valve\\Steam", "InstallPath", null) ?? throw new KeyNotFoundException("Steam installation not found");
            var vdfText = await File.ReadAllLinesAsync(Path.Combine(steamPath.ToString() ?? throw new InvalidOperationException("Invalid Steam install path"), "config\\libraryfolders.vdf"));
            var gameLineText = vdfText.FirstOrDefault(x => x.Contains("\"235800\"")) ?? throw new DirectoryNotFoundException("Game isn't listed as installed in Steam");
            var lineIndex = Array.IndexOf(vdfText, gameLineText);
            for (int i = lineIndex - 1; i >= 0; i--)
            {
                if (vdfText[i].Contains("\"path\""))
                {
                    vdfText[i] = vdfText[i].Replace("\"path\"", "");
                    var libraryPath = vdfText[i][(vdfText[i].IndexOf('\"') + 1) .. vdfText[i].LastIndexOf('\"')];
                    libraryPath = libraryPath.Replace("\\\\", "\\");
                    location = Path.Combine(libraryPath, "steamapps\\common\\Audiosurf 2");
                    break;
                }
            }

            if (string.IsNullOrWhiteSpace(location))
                throw new DirectoryNotFoundException("Unable to find Audiosurf 2 directory");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine("----------");
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
            location = path;
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

#endregion

#region Install Directory Confirmation

Console.Clear();
Console.WriteLine("Ready to install in path:");
Console.WriteLine(location);
Console.WriteLine("----------");
Console.WriteLine("Press Enter to install");
Console.ReadLine();

#endregion

#region Patch Install

Console.Clear();
var client = new HttpClient();
Console.WriteLine("Downloading files...");
var latest = await client.GetStreamAsync("https://aiae.ovh/brownie/audiosurf2_updater.zip");
var archive = new ZipArchive(latest);
Console.WriteLine("Extracting files...");
archive.ExtractToDirectory(location, true);
Console.WriteLine("Installation complete, have fun :)");
Console.WriteLine("Press Enter to exit");
Console.ReadLine();

#endregion