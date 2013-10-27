using System.Collections.Generic;
using DotNetBuild.Core;

namespace DotNetBuild.PoC.Build
{
    public class CI : ITarget
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
            get
            {
                return new List<ITarget>
                {
                    new Build(),
                    new RunTests()
                };
            }
        }

        public bool Execute(IConfigurationSettings configurationSettings)
        {
            return true;
        }
    }
}