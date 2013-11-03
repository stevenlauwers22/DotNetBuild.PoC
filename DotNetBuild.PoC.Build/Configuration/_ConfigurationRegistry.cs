using System;
using DotNetBuild.Core;

namespace DotNetBuild.PoC.Build.Configuration
{
    public class _ConfigurationRegistry : ConfigurationRegistry
    {
        public _ConfigurationRegistry()
        {
            Add(new DevelopmentConfiguration(), configuration => string.Equals(configuration, "Development", StringComparison.OrdinalIgnoreCase));
            Add(new TestConfiguration(), configuration => string.Equals(configuration, "Test", StringComparison.OrdinalIgnoreCase));
            Add(new AcceptanceConfiguration(), configuration => string.Equals(configuration, "Acceptance", StringComparison.OrdinalIgnoreCase));
            Add(new ProductionConfiguration(), configuration => string.Equals(configuration, "Production", StringComparison.OrdinalIgnoreCase));
        }
    }
}