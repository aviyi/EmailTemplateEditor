using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTemplateteService
{
    interface IDataAccess
    {
        List<branches> GetAllBranchesContaintWithBranchName(string startWith);
         
    }
}
