using api.IFTool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace api.IFTool.Repositories
{
    public interface IMasterRepository
    {
 
        Task<ProjectDeploy> ProjectDeploy(string id);
    }
}