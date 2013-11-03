using DotNetBuild.Core;

namespace DotNetBuild.PoC.Build.Configuration
{
    public class AcceptanceConfiguration : ConfigurationSettings
    {
        public AcceptanceConfiguration()
        {
            Add("ConnectionString", "Data source=acceptance;xxx");
        }
    }
}