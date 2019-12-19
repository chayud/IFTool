using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.IFTool.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace api.IFTool.Controllers
{
    [Route("[controller]")]
    
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
        [HttpGet]
        public async Task<object> ProjectDeploy([FromQuery]string branch, [FromQuery]string env)
        {

            var projectDeploy = await _masterRepository.ProjectDeploy(branch);
            var data = "";
            if (env == "dev")
            { data = projectDeploy.project + "|" + projectDeploy.dev_env; }
            else if (env == "uat")
            { data = projectDeploy.project + "|" + projectDeploy.uat_env; }
            else
            { data = projectDeploy.project + "|" + projectDeploy.prd_env; }
            

            return data;
        }


    }
}
