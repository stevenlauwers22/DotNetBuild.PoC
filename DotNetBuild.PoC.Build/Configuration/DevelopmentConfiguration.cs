using DotNetBuild.Core;

namespace DotNetBuild.PoC.Build.Configuration
{
    public class DevelopmentConfiguration : ConfigurationSettings
    {
        public DevelopmentConfiguration()
        {
            Add("ConnectionString", "Data source=localhost;xxx");
        }
    }
}