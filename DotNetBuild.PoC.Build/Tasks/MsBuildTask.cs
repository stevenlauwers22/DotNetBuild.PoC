using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DotNetBuild.PoC.Build.Tasks
{
    public class MsBuildTask
    {
        public string MsBuildExe { get; set; }
        public string Project { get; set; }
        public string Target { get; set; }
        public string Parameters { get; set; }

        public bool Execute()
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = GetMsBuildExe(),
                    Arguments = GetMsBuildParameters(),
                    UseShellExecute = false
                }
            };

            process.Start();
            process.WaitForExit();

            var exitCode = process.ExitCode;
            return exitCode == 0;
        }

        private string GetMsBuildExe()
        {
            if (IsValidMsBuildExe(MsBuildExe))
                return MsBuildExe;

            var alternativeMsBuildExes = new List<string>
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"Microsoft.Net\Framework\v4.0.30319\MSBuild.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"Microsoft.Net\Framework\v3.5\MSBuild.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"Microsoft.Net\Framework\v2.0.50727\MSBuild.exe")
            };

            foreach (var alternativeMsBuildExe in alternativeMsBuildExes)
            {
                if (IsValidMsBuildExe(alternativeMsBuildExe))
                    return alternativeMsBuildExe;
            }

            throw new InvalidOperationException("MSBuild.exe could not be found.");
        }

        private static bool IsValidMsBuildExe(string msBuildExe)
        {
            if (string.IsNullOrEmpty(msBuildExe)) 
                return false;

            var msBuildExePathInfo = new FileInfo(msBuildExe);
            if (!msBuildExePathInfo.Exists)
                return false;

            return true;
        }

        private string GetMsBuildParameters()
        {
            var parameters = new StringBuilder();
            parameters.Append(Project + " ");

            if (!string.IsNullOrEmpty(Target))
                parameters.Append("/t:" + Target + " ");

            if (!string.IsNullOrEmpty(Parameters))
                parameters.Append("/p:" + Parameters + " ");

            return parameters.ToString();
        }
    }
}