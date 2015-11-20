namespace EmailTemplateteService
{
    public class TemplateParams
    {
        public int? BranchId { get; set; }
        public int? CampaignId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}