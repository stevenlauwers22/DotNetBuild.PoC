using DotNetBuild.Core;

namespace DotNetBuild.PoC.Build.Configuration
{
    public class TestConfiguration : ConfigurationSettings
    {
        public TestConfiguration()
        {
            Add("ConnectionString", "Data source=test;xxx");
        }
    }
}