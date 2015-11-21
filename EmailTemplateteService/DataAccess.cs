using EmailTemplateteService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTemplateteService
{
    public class DataAccess : IDataAccess
    {
        public bool AddEmailTemplate(TemplateParams templateParams)
        {

            bool isAdded=false;
            using (var ctx = InitSOSDBEntities())
            {
                try
                {
                    ctx.EmailsTemplates.Add(new EmailsTemplate
                    {
                        brabch_num = templateParams.BranchId,
                        mis_campaign = templateParams.CampaignId,
                        Subject = templateParams.Subject,
                        Body = templateParams.Body,
                    });
                    ctx.SaveChanges();
                    isAdded = true;

                }
                catch
                {


                }
            }

            return isAdded;
        }

        public List<branch> GetBranches()
        {
            using (var ctx = InitSOSDBEntities())
            {
                return ctx.branches.ToList();
            }



        }

        public List<campain> GetCampaigns()
        {
            using (var ctx = InitSOSDBEntities())
            {
                return ctx.campains.ToList();
            }

        }
        private SOSDBEntities InitSOSDBEntities()
        {
            return new SOSDBEntities();
        }
    }
}
