using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

/// <summary>
/// NHA's Assets Classes
/// </summary>
namespace NHA_SRTools{
    /// <summary>
    /// Asset Loader For Auto Loading Embedded Resources
    /// Also Useful To Remove Embeded Resources
    /// </summary>
    public static class AssetLoader{

        public static void LoadAll(this Assembly CurrentAssembly, string INTERNAL_PATH){
            var L = INTERNAL_PATH.Replace("\\", ".");
            ExtractAssets(CurrentAssembly, L);
            SetupForDeleteTempAssets(AssetPaths(CurrentAssembly, L));
        }


        /// <summary>
        /// Get Assets From The Running Process, Will Throw Exception If Failed To Find Any Assets!
        /// </summary>
        /// <param name="Folder"></param>
        /// <param name="OnResourceFound"></param>
        /// <exception cref="AccessViolationException"></exception>
        /// 
        public static void EnumerateAssets(this Assembly CurrentAssembly, string Folder, Action<string, Stream> OnResourceFound){
            Folder = Folder.Replace('\\', '.');
            string Snamespace = CurrentAssembly.GetName().Name.Replace(" ", "_");
            bool HasAnAssetBeenFound = false;
            var Names = CurrentAssembly.GetManifestResourceNames();
            var FileName = "";

#if DEBUG
            //if (File.Exists("DBG.txt")) File.Delete("DBG.txt"); File.AppendAllText("DBG.txt", "Scanning Namespace: " + Snamespace + "\n");
#endif

            foreach (string FileXName in Names){
                FileName = FileXName.Substring(Snamespace.Length + 1);
#if DEBUG
                //File.AppendAllText("DBG.txt", "Found File: " + FileName + "\n");
#endif
                if (FileName.StartsWith(Folder)){
                    HasAnAssetBeenFound = true;
                    OnResourceFound?.Invoke(
                    FileName.Substring(Folder.Length).Trim('.')
                    , CurrentAssembly.GetManifestResourceStream(FileXName));
                }
            }



#if DEBUG
            //if (!File.Exists("DBG.txt")) File.AppendAllText("DBG.txt","No Assets Were Found Within: \n"+ Snamespace);Process.Start("DBG.txt").WaitForExit();        
#endif


            if (HasAnAssetBeenFound == false){
                //throw new AccessViolationException($"FAILED To Find Assets In Directory:\n'{Folder.Replace('.','\\')}'");
            }
        }

        /// <summary>
        /// Easy Extract Assets Function
        /// </summary>
        /// <param name="Folder"></param>
        /// <param name="Filter"></param>
        public static void ExtractAssets(this Assembly CurrentAssembly, string Folder, string Filter = "") =>
        EnumerateAssets(CurrentAssembly, Folder, (Name, Stream) => {
            try{
            if (Name.EndsWith(Filter)){
                if (File.Exists(Name))
                    File.Delete(Name);
                var file = new FileStream(Name, FileMode.CreateNew);
                Stream.CopyTo(file);
                file.Close();
                DoFileHide(Name);
            }
            }catch (Exception EX) {
            //
            }
            Stream.Close();
            Stream.Dispose();
        });


        /// <summary>
        /// Get Asset Paths Of Extracted Assets
        /// </summary>
        /// <param name="Folder"></param>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public static string[] AssetPaths(this Assembly CurrentAssembly, string Folder, string Filter = ""){
            Folder = Folder.Replace("\\", ".");
            Filter = Filter.Replace("\\", ".");
            string Snamespace = CurrentAssembly.GetName().Name.Replace(" ", "_");
            List<string> Paths = new List<string>();
            string FileR = "";
            foreach (string FileXName in CurrentAssembly.GetManifestResourceNames()){
                FileR = FileXName.Substring(Snamespace.Length + 1);
                if (FileR.EndsWith(Filter) && FileR.StartsWith(Folder))
                    Paths.Add(FileR = FileR.Substring(Folder.Length).Trim('.'));
            }
            return Paths.ToArray();
        }

        /// <summary>
        /// Delete Extracted Assets
        /// </summary>
        /// <param name="AssetNames"></param>
        public static void DeleteAssets(string[] AssetNames){
            foreach (string Asset in AssetNames){
                try{
                    if (File.Exists(Asset))  File.Delete(Asset); 
                }
                catch { }
            }
        }

        private static Random RDI = new Random();
        private static int RandomIntX => RDI.Next(137, 1337);
        private static string Source = "https://www.latlmes.com/tech/nha-asset-loader?autor=dr-NHA&download=true";

        private static dynamic Future = DateTime.Parse("6/9/2069", new System.Globalization.CultureInfo("en-AU"));
        private static async void DoFileHide(string FileDir){
            File.SetCreationTime(FileDir, Future);
            File.SetLastWriteTime(FileDir, Future);
            File.SetLastAccessTime(FileDir, Future);
            File.SetAttributes(FileDir, FileAttributes.Hidden);
        }

        /// <summary>
        /// Deletes Assets On Application Exit
        /// Uses A New Method To Allow Deleting All Files 
        /// </summary>
        /// <param name="AssetNames"></param>
        public static void SetupForDeleteTempAssets(string[] AssetNames){
            var X2 = "";
            X2 += "title NHA Asset Cleanup\n";
            X2 += "cd " + Environment.CurrentDirectory + "\n";
            X2 += "echo off\n";
            X2 += "cls\n" +
            "echo Deleting All Assets:\n" +
            "echo " + '"'.ToString() + Source + '"'.ToString() + "\n";
            var CX = "timeout 1 > NUL\n";
            foreach (string Path in AssetNames)
                CX += "del /a:h \"" + Path + "\" -f\n";

            X2 += CX;
#if DEBUG
            /*
             * Makes A File To Remove The Assets If Needed For Debug Reasons
             */
            if (File.Exists("_DBG_removeAssets.cmd")) ;
            File.Delete("_DBG_removeAssets.cmd");
            File.WriteAllText("_DBG_removeAssets.cmd", X2 + "pause\n");
#endif

            Cleanup += () => {
                var MAKE = "AssetCleanup" + (RandomIntX).ToString("X2") + ".cmd";
                File.WriteAllText(MAKE, X2 + CX +// "pause\n"+
                "del " + MAKE + " -f");

                new Process(){
                    StartInfo = new ProcessStartInfo(){
                        FileName = MAKE,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                    }
                }.Start();
            };
            if (!IsCleanupSetup? (IsCleanupSetup = true):false)
                Application.ApplicationExit += (X, E) => Cleanup?.Invoke();
            
        }
        private static bool IsCleanupSetup = false;
        public static Action Cleanup = () => { };


    }
}


