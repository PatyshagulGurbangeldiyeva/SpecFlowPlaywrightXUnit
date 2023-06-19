using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPlaywrightXUnit.Utilities
{
    public class CommonMethods
    {

        [Obsolete]
        public static string GetCurrentProjectDirectory()
        {
            string pth = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath=new Uri(actualPath).LocalPath;
            return projectPath;
        }

        //method returns the current working directory (i.e. \bin\Debug\)
        public static string GetWorkingDirectoryDebug()
        {
            string workingDirectoryDebug=Directory.GetCurrentDirectory(); // or Environment.CurrentDirectory
            return workingDirectoryDebug; 
        }

        //method returns the current project bin directory (i.e. \bin\)
        public static string GetProjectDirectory()
        {
            string projectDirectory = Directory.GetParent(GetWorkingDirectoryDebug()).Parent.FullName;
            return projectDirectory;
        }






        //public static string GetConfigData(String key)
        //{
        //    return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("Configs.json")
        //    .Build()
        //    .GetSection(key).Value;
        //}



        ////get the value from ConfigsTest json file
        //public static string GetConfigTestData(String key)
        //{
        //    return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("ConfigsTest.Json")
        //        .Build()
        //        .GetSection(key).Value;

        //}
    }
}
