using System;
using System.IO;
using DotNetBuild.Core;
using DotNetBuild.Tasks;

namespace DotNetBuild.PoC.Build
{
    public class Configurator : IConfigurator
    {
        public void Configure()
        {
            "ci"
                .Target("Continuous integration target")
                .DependsOn("buildRelease")
                .And("runTests");

            "buildRelease"
                .Target("Build in release mode")
                .Do(context =>
                {
                    var solutionDirectory = context.ConfigurationSettings.Get<String>("SolutionDirectory");
                    var msBuildTask = new MsBuildTask
                    {
                        Project = Path.Combine(solutionDirectory, "DotNetBuild.PoC.sln"),
                        Target = "Rebuild",
                        Parameters = "Configuration=Release"
                    };

                    return msBuildTask.Execute();
                });

            "runTests"
                .Target("Run tests")
                .Do(context =>
                {
                    var solutionDirectory = context.ConfigurationSettings.Get<String>("SolutionDirectory");
                    var xunitExe = context.ConfigurationSettings.Get<String>("PathToXUnitRunnerExe");
                    var xunitTask = new XunitTask
                    {
                        XunitExe = Path.Combine(solutionDirectory, xunitExe),
                        Assembly = Path.Combine(solutionDirectory, @"DotNetBuild.PoC.Tests\bin\Release\DotNetBuild.PoC.Tests.dll")
                    };

                    return xunitTask.Execute();
                });

            "defaultConfig"
                .Configure()
                .AddSetting("SolutionDirectory", @"..\")
                .AddSetting("PathToXUnitRunnerExe", @"packages\xunit.runners.1.9.2\tools\xunit.console.clr4.exe");
        }
    }
}