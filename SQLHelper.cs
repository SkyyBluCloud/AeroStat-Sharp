using System.Configuration;

namespace AeroStat_Sharp
{
    public static class SQLHelper
    {
        public static string cnnVal()
        {
            return ConfigurationManager.ConnectionStrings["AeroStat_Sharp.Properties.Settings.testAeroStat"].ConnectionString;
        }
    }
}
