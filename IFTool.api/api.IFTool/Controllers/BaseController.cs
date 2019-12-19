using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api.IFTool.Models;
using api.IFTool.Repositories;
using api.IFTool.Services;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace api.IFTool.Controllers
{
    public class BaseController : Controller
    {
        public IDbConnection DbConnection { get; set; }

        private IMemoryCache _cache;
        

        private readonly IConfiguration _configuration;

        protected Connsettings _connSetting { get; private set; }

        readonly ILogger<BaseController> _log;

        private readonly IMasterRepository _masterRepository;


        public BaseController()
        {
            
            _connSetting = ProviderServiceUtil.Configuration.GetSection("ConnSettings").Get<Connsettings>();

            var x = Environment.GetEnvironmentVariable("ConnectionString");
            DbConnection = DbConnection = new SqlConnection(Environment.GetEnvironmentVariable("ConnectionString"));

            //_masterRepository = new MasterRepository(DbConnection);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        internal static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }

        public bool VerifyHeader(out string ErrorMsg)
        {

            if (AppSettingServiceProvider.UseHeaderVerification == "N" || AppSettingServiceProvider.UseHeaderVerification == "n")
            {
                ErrorMsg = " ------ W A R N I N G --------- /r/n ByPass Header Verification!";
                return true;
            }
            string ipaddress = "5555555";
            StringValues api_Header;
            StringValues APIKey;

            var isValidHeader = false;
            //APIITVendor //VendorData = new APIITVendor();
            if (Request.Headers.TryGetValue("APIHeader", out api_Header) && Request.Headers.TryGetValue("APIKey", out APIKey))
            {
                string authHeaderKey = api_Header.First();
                string authHeaderToken = APIKey.First();

                if (!string.IsNullOrEmpty(authHeaderKey) && !string.IsNullOrEmpty(authHeaderToken))
                {
                    //Get Vendor Key and Validate is Key Correct?
                    for (int i = 0; i < KeyAndTokenExtention.KeyAndTokenProvider.Count(); i++)
                    {
                        if (KeyAndTokenExtention.KeyAndTokenProvider[i].ApiHeader == authHeaderKey &&
                            KeyAndTokenExtention.KeyAndTokenProvider[i].ApiKey == authHeaderToken)
                        {
                            isValidHeader = true;
                        }
                    }

                    if (!isValidHeader)
                    {
                        ErrorMsg = ipaddress + " :: Missing Authorization Header.";
                        return false;  //BadRequest("Missing Authorization Header.");
                    }
                }
            }
            else
            {
                if (!isValidHeader)
                {
                    //_log.LogDebug(ipaddress + " :: Missing Authorization Header.");
                    ErrorMsg = ipaddress + " :: Missing Authorization Header.";
                    //VendorData = new APIITVendor();
                    return false;
                    //  return BadRequest("Missing Authorization Header.");
                }
            }
            //VendorData = new APIITVendor();
            ErrorMsg = "Header Verify";
            return true;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

        }

        public string[] SaveUploadFile(ref IFormFile file, string fileKey, string pathSave, bool convertReturnVPathToRelativePath)
        {


            try
            {

                //DirectoryInfo fileExists = new DirectoryInfo(pathSave);

                //if (!fileExists.Exists)
                //    fileExists.Create();

                //foreach (FileInfo file in fileExists.GetFiles())
                //{
                //    file.Delete();
                //}

                var yearUpload = DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                var monthUpload = DateTime.Now.ToString("MM", CultureInfo.CreateSpecificCulture("en-US"));
                var dateUpload = DateTime.Now.ToString("ddMMyyyyHHmmssfff", CultureInfo.CreateSpecificCulture("en-US"));
                string filePath = "";
                string fileName = "";

                List<string> filelist = new List<string>();
                if (file != null)
                {
                    var uploadFile = file;

                    if (uploadFile.Length > 0)
                    {

                        filePath = Path.GetTempFileName();

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            uploadFile.CopyToAsync(stream);
                        }
                        //fileName = uploadFile.FileName;
                        //filePath = string.Concat(pathSave.TrimEnd('\\') + ("\\" + yearUpload), ("\\" + monthUpload), "\\");
                        //fileName = string.Concat(pathSave.TrimEnd('\\') + ("\\" + yearUpload), ("\\" + monthUpload), "\\", fileName);
                        //uploadFile.CopyTo(new FileStream(filePath, FileMode.Create));
                        //filelist.Add(fileName);

                    }

                    if (convertReturnVPathToRelativePath)
                    {
                        var relativePaths = new List<string>();
                        foreach (var path in filelist)
                        {
                            if (path.StartsWith("~/"))
                                relativePaths.Add(path.Replace("~/", ""));
                            else
                                relativePaths.Add(path);
                        }
                        filelist = relativePaths;
                    }

                    return filelist.ToArray();
                }

                return new string[] { "" };

            }
            catch (Exception ex)
            {

                throw new Exception("Base.SaveUploadFile() :: ", ex);


            }

        }

    }
}