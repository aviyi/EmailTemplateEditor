using EmailTemplateteService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTemplateteService
{
    public interface IDataAccess
    {
        List<branches> GetBranches();
        List<campains> GetCampaigns();
        bool AddEmailTemplate(TemplateParams templateParams);
         

    }
}
