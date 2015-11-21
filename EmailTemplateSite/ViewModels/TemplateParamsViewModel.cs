using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTemplateSite.ViewModels
{
    public class TemplateParamsViewModel
    {

        public short? BranchId { get; set; }
        public int? CampaignId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
