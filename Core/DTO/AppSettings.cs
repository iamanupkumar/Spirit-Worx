using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO;

public class AppSettings
{
    static AppSettings()
    {
        ConnectionStrings = AppSettingsHelper.ConnectionStrings();
        JWT = AppSettingsHelper.JWT();
    }
    public static ConnectionStringsSection? ConnectionStrings { get; }
    public static JwtSection? JWT { get; }
    public class ConnectionStringsSection
    {
        #region # Keys
        public string DBConnection { get; set; } = string.Empty;
        #endregion
    }

    public class JwtSection
    {
        #region # Keys

        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public double DurationInHours { get; set; }

        #endregion
    }
}
