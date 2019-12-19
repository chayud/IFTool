using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.IFTool.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace api.IFTool.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        private readonly IMasterRepository _masterRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;

        public ValuesController(IConfiguration configuration, IMasterRepository masterRepo, IUnitOfWork unitOfWork)
        {
            _masterRepository = masterRepo;
            _unitOfWork = unitOfWork;
            _config = configuration;
        }

        // GET ProjectDeploy/values
        [HttpGet("ProjectDeploy")]
        public async Task<object> ProjectDeploy([FromQuery]string branch, [FromQuery]string b)
        {
            try
            {

                if (branch==null || b == null)
                {
                    var text = "{\"branch2\":" + branch + ",\"env\":" + b + "}";
                    return text;
                }
                var projectDeploy = await _masterRepository.ProjectDeploy(branch);
                var data = "";
                if (projectDeploy != null)
                {
                    if (b == "dev")
                    { data = projectDeploy.dev_project + "|" + projectDeploy.dev_env; }
                    else if (b == "uat")
                    { data = projectDeploy.uat_project + "|" + projectDeploy.uat_env; }
                    else if (b == "prd")
                    { data = projectDeploy.prd_project + "|" + projectDeploy.prd_env; }
                }
                else
                {
                    var text = "{\"branch\":" + branch + ",\"env\":" + b + "}";
                    return text;
                }
                


                return data;
            }
            catch (Exception ex)
            {
                
                return ex;
            }
          
        }


    }
}
