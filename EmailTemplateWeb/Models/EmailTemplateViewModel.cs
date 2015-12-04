using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmailTemplateWeb.Models
{
    public class EmailTemplateViewModel
    {

        public int Id { get; set; }

        [Display(Name = "סניף")]
        public string BranchName { get; set; }
        [Display(Name = "קמפיין")]
        public string CampaignName { get; set; }
        [Required]
        [Display(Name = "נושא")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "גוף המייל")]
        public string Body { get; set; }

    }
}
