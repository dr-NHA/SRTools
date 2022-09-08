using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NHA_SRTools{
public static class SrTool{
        
/// <summary>
/// The srtools Exe File
/// </summary>
public static string srtools { get; } = "srtools_x64.exe";

/// <summary>
/// Threads Amount (1-50) Default = 10
/// </summary>
public static int Threads { get; set; } =10;
/// <summary>
/// Don't compress any files when packing. Might be a bit more stable.
/// </summary>
public static bool NoCompression { get; set; } =false;
private static string NoCompression_=> NoCompression?"-n":"";
private static string UnpackCMD(string FilePath,string FileName) =>
$"unpack -i \"{FilePath}\" -o \"{FilePath.Substring(0, FilePath.LastIndexOf(FileName))}\\{FileName}_Unpacked\" -t {Threads}";
private static string UnpackCMD(string FilePath) =>UnpackCMD(FilePath, FilePath.Split('\\').Last().Split('.')[0]) ;


public static Process UnpackFile(string FilePath, Action<string> DataRecieved, Action OnExited = null) =>
ExecuteSRToolCommand(UnpackCMD(FilePath), DataRecieved,OnExited);

private static ProcessStartInfo ProcessStartInfo(string FileName, string Arguments, ProcessWindowStyle ProcessWindowStyle= ProcessWindowStyle.Hidden) =>new ProcessStartInfo() {
UseShellExecute = false,
RedirectStandardOutput = true,
FileName = FileName,
Arguments = Arguments,
CreateNoWindow = true,
WindowStyle = ProcessWindowStyle,
};


public static Process ExecuteSRToolCommand(string Arguments,Action<string> DataRecieved, Action OnExited = null){
var NProcess = new Process() { StartInfo= ProcessStartInfo(srtools, Arguments, ProcessWindowStyle.Hidden)};
NProcess.Start();
bool Exited = false;
string L = null;
var FIN="Finished in ";
Task.Run(async () => {
while (!Exited){
L = await NProcess.StandardOutput.ReadLineAsync(); 
if (L != null) { 
DataRecieved.Invoke(L);
if (!NProcess.HasExited? L.StartsWith(FIN):false){
NProcess.Kill();}
}
await Task.Delay(1);
}
});

NProcess.Exited += (X, E) => {
Exited = true;
OnExited?.Invoke();
};
return NProcess;
}



    }
}
