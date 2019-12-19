using DapperExtensions;
using Microsoft.Extensions.Configuration;
using api.IFTool.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Dapper;
using Microsoft.AspNetCore.Hosting.Internal;
using System.IO;
using System.Text;
using System.Reflection;
using System.Globalization;
using Utility;

namespace api.IFTool.Repositories
{
    public class MasterRepository : BaseRepository, IMasterRepository, IDisposable
    {
        const string TAG = "MasterRepository";

        public IConfiguration _config { get; }
        private readonly IHostingEnvironment _hostingEnvironment;
        private IDbConnection Conn;
        protected Connsettings _connSetting { get; private set; }

        internal IDbConnection CreateConnection()
        {
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();
            return Conn;
        }
        public MasterRepository(IHostingEnvironment environment, IConfiguration config) : base(environment, config)
        {
            _config = config;
            _hostingEnvironment = environment;
            this.Conn = Connection;
        }

        public void Dispose()
        {
            if (Conn.State == ConnectionState.Open)
                Conn.Close();

        }



        public async Task<ProjectDeploy> ProjectDeploy(string id)
        {

            try
            {
                CreateConnection();

                    var sql = string.Format(@"SELECT * FROM ProjectDeploy WHERE branch = @a");

                var items = Conn.Query<ProjectDeploy>(sql, new { @a = id }).FirstOrDefault() ?? new ProjectDeploy();

                    return items;
                
            }
            catch (Exception ex)
            {
                ex.HelpLink = Connection.ConnectionString;

                throw ex;
            }

        }

    }
}
