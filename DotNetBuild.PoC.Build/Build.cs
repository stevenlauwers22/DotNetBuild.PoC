using System.Collections.Generic;
using System.IO;
using DotNetBuild.Core;
using DotNetBuild.PoC.Build.Tasks;

namespace DotNetBuild.PoC.Build
{
    public class Build : ITarget
    {
        public string Name
        {
            get { return "Continuous integration target"; }
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
            var msBuildTask = new MsBuildTask
            {
                Project = Path.Combine(baseDir, "DotNetBuild.Poc.sln"),
                Target = "Rebuild",
                Parameters = "Configuration=Debug"
            };

            return msBuildTask.Execute();
        }
    }
}