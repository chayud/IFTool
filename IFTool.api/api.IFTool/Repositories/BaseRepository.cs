using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using api.IFTool.Models;
using System.Collections.Generic;
using System;

namespace api.IFTool.Repositories
{
    public abstract class BaseRepository
    {
        private readonly string _ConnectionString;
        private readonly IConfiguration _config;
        protected int ConnctionLongQuerryTimeOut = 600;
        public int longQueryTimeOut = 30000;
        private readonly IHostingEnvironment _hostingEnvironment;

        public BaseRepository(IHostingEnvironment environment, IConfiguration config)
        {
            _config = config;
            _hostingEnvironment = environment;
            _ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");


        }
        protected IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_ConnectionString);
            }
        }

        internal string SqlParamsGenerator(List<SqlWhereCondition> searchParams)
        {


            string whereCondition = "";
            foreach (var con in searchParams)
            {

                if (con.IsCustomQuery && con.Value is string)
                {
                    whereCondition += string.Format(" {0} ", con.Value);
                }
                else if (con.Value != null && con.Value is int)
                {
                    whereCondition += string.Format("AND ( {0} {1} {2} ) ", con.Field, con.Condition, con.Value);
                }
                else if (con.Value != null && con.Value is string)
                {
                    whereCondition += string.Format("AND ( {0} {1} '{2}' ) ", con.Field, con.Condition, con.Value);
                }
                else if (con.Value != null && con.Value is DateTime)
                {
                    whereCondition += string.Format("AND ( {0} {1} '{2}' ) ", con.Field, con.Condition,
                        ((DateTime)con.Value).ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                }
                else if (con.Value != null && con.Value is DateTime[])
                {
                    var dateCArr = (DateTime[])con.Value;
                    whereCondition += string.Format("AND ( {0} BETWEEN '{2}' AND '{3}' ) ", con.Field, con.Condition,
                        dateCArr[0].ToString("s", System.Globalization.CultureInfo.InvariantCulture),
                        dateCArr[1].ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                }
                else if (con.Value != null && con.Value is DateTime?[])
                {
                    var dateCArr = (DateTime?[])con.Value;
                    if (dateCArr[0].HasValue && dateCArr[1].HasValue)
                    {
                        whereCondition += string.Format("AND ( {0} BETWEEN '{2}' AND '{3}' ) ", con.Field, con.Condition,
                            dateCArr[0].Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture),
                            dateCArr[1].Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                else if (con.Value != null && con.Value is string[] && con.Condition == "IN")
                {
                    whereCondition += string.Format("AND ( {0} {1} ({2}) ) ", con.Field, con.Condition, string.Join(",", con.Value as string[]));
                }

                else if (con.Value != null && con.Value is string && con.Condition is string)
                {

                    whereCondition += string.Format("AND ( {0} {1} ({2}) ) ", con.Field, con.Condition, con.Value);
                }


            }

            return whereCondition;

        }
    }
}
