using Core.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

public class SignInRequest
{
    [Required(ErrorMessage = "Email Id is required.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Email Id must be between 5 and 100 characters.")]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
    public string EmailId { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
    [NoSpaces]
    public string Password { get; set; }
}
