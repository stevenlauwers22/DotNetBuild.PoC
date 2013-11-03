using System.Collections.Generic;
using DotNetBuild.Core;
using DotNetBuild.PoC.Build.Tasks;

namespace DotNetBuild.PoC.Build
{
    public class Build : ITarget
    {
        public string Name
        {
            get { return "Build target"; }
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
            var msBuildTask = new MsBuildTask
            {
                Project = @".\DotNetBuild.Poc.sln",
                Target = "Rebuild",
                Parameters = "Configuration=Debug"
            };

            return msBuildTask.Execute();
        }
    }
}