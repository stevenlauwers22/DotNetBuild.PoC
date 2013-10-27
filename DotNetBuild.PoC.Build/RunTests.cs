using System.Collections.Generic;
using System.IO;
using DotNetBuild.Core;
using DotNetBuild.PoC.Build.Tasks;

namespace DotNetBuild.PoC.Build
{
    public class RunTests : ITarget
    {
        public string Name
        {
            get { return "Run tests"; }
        }

        public bool ContinueOnError
        {
            get { return false; }
        }

        public IEnumerable<ITarget> DependsOn
        {
            get { return null; }
        }

        public bool Execute(IConfigurationSettings configurationSettings)
        {
            var baseDir = ".";// configurationSettings.Get<string>("baseDir");
            var xunitTask = new XunitTask
            {
                XunitExe = Path.Combine(baseDir, @"packages\xunit.runners.1.9.2\tools\xunit.console.clr4.exe"),
                Assembly = Path.Combine(baseDir, @"DotNetBuild.PoC.Tests\bin\Debug\DotNetBuild.PoC.Tests.dll")
            };

            return xunitTask.Execute();
        }
    }
}