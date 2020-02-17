using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace FB_DataApp.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        #region general settings
        //clinic id
        private const string ClinicIDKey = "Clinic_id";
        private static readonly string ClinicIDDefault = string.Empty;
        //clinic name
        private const string ClinicnameKey = "Clinic_name";
        private static readonly string ClinicnameDefault = string.Empty;
        //district
        private const string DistrictKey = "District";
        private static readonly string DistrictDefault = string.Empty;
        //Workplace id
        private const string WKPKey = "WKP_id";
        private static readonly string WKPDefault = string.Empty;
        //Workplace id
        private const string WKPnameKey = "WKP_name";
        private static readonly string WKPnameDefault = string.Empty;
        //Back Up
        private const string BKupKey = "BKup_id";
        private static readonly string BKupDefault = string.Empty;
        //Back Up
        private const string CKTKey = "CKT_id";
        private static readonly string CKTDefault = string.Empty;
        #endregion
        #region admin settings
        //url
        private const string URLKey = "URL";
        private static readonly string URLDefault = string.Empty;

        //username
        private const string UsernameKey = "Username";
        private static readonly string UsernameDefault = string.Empty;

        //password
        private const string PasswordKey = "Password";
        private static readonly string PasswordDefault = string.Empty;
        #endregion
        #region Setting Constants
        //default
        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;
        //Pid
        private const string PIDKey = "PID";
        private static readonly string PIDDefault = string.Empty;
        //Lay Health Worker ID
        private const string LHWIDKey = "LHWID";
        private static readonly string LHWIDDefault = string.Empty;
        //clinic id
        private const string CLIDKey = "CLID";
        private static readonly string CLIDDefault = string.Empty;
        //LHW password
        private const string LHWPass = "LHWPass";
        private static readonly string LHWPassDefault = string.Empty;
        //language
        private const string Languagekey = "Language";
        private static readonly string MyLanguage = string.Empty;
        //answer 1
        private const string qsn1 = "Qsn1";
        private static readonly string answer1 = string.Empty;
        //answer 2
        private const string qsn2 = "Qsn2";
        private static readonly string answer2 = string.Empty;
        //answer 3
        private const string qsn3 = "Qsn3";
        private static readonly string answer3 = string.Empty;
        //answer 4
        private const string qsn4 = "Qsn4";
        private static readonly string answer4 = string.Empty;
        //answer 5
        private const string qsn5 = "Qsn5";
        private static readonly string answer5 = string.Empty;
        //answer 6
        private const string qsn6 = "Qsn6";
        private static readonly string answer6 = string.Empty;
        //answer 7
        private const string qsn7 = "Qsn7";
        private static readonly string answer7 = string.Empty;
        //answer 8
        private const string qsn8 = "Qsn8";
        private static readonly string answer8 = string.Empty;
        //answer 9
        private const string qsn9 = "Qsn9";
        private static readonly string answer9 = string.Empty;
        //answer 10
        private const string qsn10 = "Qsn10";
        private static readonly string answer10 = string.Empty;
        //answer 11
        private const string qsn11 = "Qsn11";
        private static readonly string answer11 = string.Empty;
        //answer 12
        private const string qsn12 = "Qsn12";
        private static readonly string answer12 = string.Empty;
        //answer 13
        private const string qsn13 = "Qsn13";
        private static readonly string answer13 = string.Empty;
        //answer 14
        private const string qsn14 = "Qsn14";
        private static readonly string answer14 = string.Empty;
        #endregion
        #region
        /// <summary>
        /// Sms configuration- consists of:
        /// 1) Token 
        /// 2) Account name
        /// 3) Passord
        /// </summary>
        #endregion
        //answer 14
        private const string Token = "SmsToken";
        private static readonly string MyToken = string.Empty;

        private const string Username = "MyUser";
        private static readonly string MyUser = string.Empty;

        private const string Password = "MyPass";
        private static readonly string MyPassword = string.Empty;

        private const string Number = "MyNumber";
        private static readonly string MyNumber = string.Empty;

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }
        public static string PID
        {
            get
            {
                return AppSettings.GetValueOrDefault(PIDKey, PIDDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(PIDKey, value);
            }
        }
        public static string LHWID
        {
            get
            {
                return AppSettings.GetValueOrDefault(LHWIDKey, LHWIDDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LHWIDKey, value);
            }
        }
        public static string CID
        {
            get
            {
                return AppSettings.GetValueOrDefault(CLIDKey, CLIDDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(CLIDKey, value);
            }
        }
        public static string CLHWPass
        {
            get
            {
                return AppSettings.GetValueOrDefault(LHWPass, LHWPassDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LHWPass, value);
            }
        }
        public static string Language
        {
            get
            {
                return AppSettings.GetValueOrDefault(Languagekey, MyLanguage);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Languagekey, value);
            }
        }
        public static string ssq1
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn1, answer1);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn1, value);
            }
        }
        public static string ssq2
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn2, answer2);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn2, value);
            }
        }
        public static string ssq3
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn3, answer3);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn3, value);
            }
        }
        public static string ssq4
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn4, answer4);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn4, value);
            }
        }
        public static string ssq5
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn5, answer5);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn5, value);
            }
        }
        public static string ssq6
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn6, answer6);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn6, value);
            }
        }
        public static string ssq7
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn7, answer7);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn7, value);
            }
        }
        public static string ssq8
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn8, answer8);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn8, value);
            }
        }
        public static string ssq9
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn9, answer9);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn9, value);
            }
        }
        public static string ssq10
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn10, answer10);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn10, value);
            }
        }
        public static string ssq11
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn11, answer11);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn11, value);
            }
        }
        public static string ssq12
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn12, answer12);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn12, value);
            }
        }
        public static string ssq13
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn13, answer13);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn13, value);
            }
        }
        public static string ssq14
        {
            get
            {
                return AppSettings.GetValueOrDefault(qsn14, answer14);
            }
            set
            {
                AppSettings.AddOrUpdateValue(qsn14, value);
            }
        }
        public static string SmsToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(Token, MyToken);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Token, value);
            }
        }
        public static string SmsUser
        {
            get
            {
                return AppSettings.GetValueOrDefault(Username, MyUser);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Username, value);
            }
        }
        public static string SmsPass
        {
            get
            {
                return AppSettings.GetValueOrDefault(Password, MyPassword);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Password, value);
            }
        }
        //general settings
        public static string ClinicId
        {
            get
            {
                return AppSettings.GetValueOrDefault(ClinicIDKey, ClinicIDDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ClinicIDKey, value);
            }
        }
        public static string Workplace
        {
            get
            {
                return AppSettings.GetValueOrDefault(WKPKey, WKPDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(WKPKey, value);
            }
        }
        public static string BackUp
        {
            get
            {
                return AppSettings.GetValueOrDefault(BKupKey, BKupDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(BKupKey, value);
            }
        }
        public static string ClinicName
        {
            get
            {
                return AppSettings.GetValueOrDefault(ClinicnameKey, ClinicnameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ClinicnameKey, value);
            }
        }
        public static string District
        {
            get
            {
                return AppSettings.GetValueOrDefault(DistrictKey, DistrictDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(DistrictKey, value);
            }
        }
        public static string WkpName
        {
            get
            {
                return AppSettings.GetValueOrDefault(WKPnameKey, WKPnameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(WKPnameKey, value);
            }
        }
        public static string URL
        {
            get
            {
                return AppSettings.GetValueOrDefault(URLKey, URLDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(URLKey, value);
            }
        }
        public static string UrlUsername
        {
            get
            {
                return AppSettings.GetValueOrDefault(UsernameKey, UsernameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UsernameKey, value);
            }
        }
        public static string UrlPassword
        {
            get
            {
                return AppSettings.GetValueOrDefault(PasswordKey, PasswordDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(PasswordKey, value);
            }
        }
        public static string CKT
        {
            get
            {
                return AppSettings.GetValueOrDefault(CKTKey, CKTDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(CKTKey, value);
            }
        }
    }
}