
using EmailTemplateteService;
using EmailTemplateteService.Entities;
using EmailTemplateTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EmailTemplateTest
{
    [TestClass]
    public class EmailTemplateServiceTest
    {


        [TestMethod]
        public void Test_That_Return_3_Branches_That_Contains_Name_A()
        {

            var mock = new MockDataAccess();
            var templateService = new EmailTemplateService(mock);
            var branches = new List<branches>
            {
                new branches
                {
                    name ="Avi"
                },

                new branches
                {
                    name ="ALex"
                }, new branches
                {
                    name="Beni",
                }
                , new branches
                {
                    name="A",
                },


            };

            mock.FillBranches(branches);
            Assert.AreEqual(templateService.GetBranchesContainBranchName("A").Count, 3);
        }

        [TestMethod]
        public void Test_That_Return_2_Campaigns_That_Contains_Name_B()
        {

            var mock = new MockDataAccess();
            var templateService = new EmailTemplateService(mock);
            var campaigns = new List<campains>
            {
                new campains
                {
                   teur_campain = "BBBB"
                },

                new campains
                {

                   teur_campain = "BAABB"
                }, new campains
                {
                   teur_campain = "AAAA",
                }
                , new campains
                {
                   teur_campain = "CC",
                },


            };

            mock.FillCampaigns(campaigns);
            Assert.AreEqual(templateService.GetCampaignsContainCampaignName("B").Count, 2);
        }
    }
}
