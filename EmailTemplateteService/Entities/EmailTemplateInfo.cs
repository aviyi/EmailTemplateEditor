namespace EmailTemplateteService
{
    public class EmailTemplateInfo
    {
        public int Id { get; set; }
        
        public string Subject { get; set; }
        public string Body { get; set; }
        public BranchInfo BranchInfo { get; set; }
        public CampaignInfo CampaignInfo { get; set; }

    }
}