using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.IFTool.Services
{
    public static class SettingServiceProvider
    {
        public static IConfiguration Configuration { get; set; }

        public static string ADUser { get; set; }
        public static string ADPassword { get; set; }
        public static string ADOU { get; set; }
        public static string ADPath { get; set; }
        public static string ADResetPasswordrl { get; set; }
        public static string ADSplPassword { get; set; }
        public static string ADDomain { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string MaxExpireDay { get; set; }
        public static string AlertBeforeExpireDay { get; set; }
        public static string ChangePasswordUrl { get; set; }
        public static string WebDirectoryPath { get; set; }
    }
}
