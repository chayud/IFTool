using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.IFTool.Services
{
    public static class AppSettingServiceProvider
    {
        public static IConfiguration Configuration { get; set; }

        public static string VirtualDirectory { get; set; }
        public static string IsProduction { get; set; }
        public static string IsMailTo { get; set; }
        public static string UseHeaderVerification { get; set; }
        public static string APIKey { get; set; }
        public static string DirRoot { get; set; }
        public static string ZipPath { get; set; }
        public static string StroageID { get; set; }
        public static string AuthorizeAPIKey { get; set; }
        public static string AuthorizeAPIToken { get; set; }
        public static string AuthorizeAPIUrl { get; set; }
        public static string MailAPIUrl { get; set; }
    }
}