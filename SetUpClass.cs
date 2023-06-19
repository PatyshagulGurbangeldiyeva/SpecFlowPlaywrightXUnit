using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPlaywrightXUnit
{

    [Collection("Specflow Playwright Collection")]
    public class SetUpClass
    {
        public static string HostName = System.Environment.MachineName;
        public static string TestName = "";
        public static string TestEnv = "";
        public static string URL = "";
        public static string userName1 = "";
        public static string pwd = "";


        private static string GetEnv = "";

        private static IConfiguration? config;

        //get access to Json file
        private static IConfiguration GetConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Configs.json")
                .Build();
        }


        //setting up the datas from json file
        public static void TestSetUp()
        {
            config= GetConfigurationRoot();
            GetEnv = config["TestConfig:TestEnv"];

            if (GetEnv != null)
            {
                TestEnv = GetEnv;
            }
            else
            {
                TestEnv = config["TestConfig:TestEnv"];
            }


            if (TestEnv =="QA") 
            {
                URL = config["TestConfig:QAConfig:URL"];
                userName1 = config["TestConfig:QAConfig:username1"];
                pwd = config["TestConfig:QAConfig:pwd"];
            }
            else if (TestEnv =="Dev")
            {
                URL = config["TestConfig:DevConfig:URL"];
                userName1 = config["TestConfig:DevConfig:username1"];
                pwd = config["TestConfig:DevConfig:pwd"];
            }
            else if (TestEnv =="Prod")
            {
                URL = config["TestConfig:ProdConfig:URL"];
                userName1 = config["TestConfig:ProdConfig:username1"];
                pwd = config["TestConfig:ProdConfig:pwd"];
            }
            else
            {
                URL = config["TestConfig:QAConfig:URL"];
                userName1 = config["TestConfig:QAConfig:username1"];
                pwd = config["TestConfig:QAConfig:pwd"];
            }


        }



    }
}
