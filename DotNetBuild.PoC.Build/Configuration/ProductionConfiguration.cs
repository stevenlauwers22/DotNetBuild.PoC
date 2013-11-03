using DotNetBuild.Core;

namespace DotNetBuild.PoC.Build.Configuration
{
    public class ProductionConfiguration : ConfigurationSettings
    {
        public ProductionConfiguration()
        {
            Add("ConnectionString", "Data source=production;xxx");
        }
    }
}