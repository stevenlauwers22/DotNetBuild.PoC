using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DotNetBuild.PoC.Build.Tasks
{
    public class XunitTask
    {
        public string XunitExe { get; set; }
        public string Assembly { get; set; }

        public bool Execute()
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = GetXunitExe(),
                    Arguments = GetXunitParameters(),
                    UseShellExecute = false
                }
            };

            process.Start();
            process.WaitForExit();

            var exitCode = process.ExitCode;
            return exitCode == 0;
        }

        private string GetXunitExe()
        {
            if (IsValidXunitExe(XunitExe))
                return XunitExe;

            throw new InvalidOperationException("MSBuild.exe could not be found.");
        }

        private static bool IsValidXunitExe(string nunitExe)
        {
            if (string.IsNullOrEmpty(nunitExe))
                return false;

            var nunitExePathInfo = new FileInfo(nunitExe);
            if (!nunitExePathInfo.Exists)
                return false;

            return true;
        }

        private string GetXunitParameters()
        {
            var parameters = new StringBuilder();
            parameters.Append(Assembly + " ");

            return parameters.ToString();
        }
    }
}