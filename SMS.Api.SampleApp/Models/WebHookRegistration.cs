using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS.Api.SampleApp.Models
{
    public class WebHookRegistration
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "WebHook Url")]
        public string WebHookUri { get; set; }

        [Display(Name = "Secret")]
        public string Secret { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Filters")]
        public IList<string> SelectedFilterValues { get; set; }

        public IList<string> AvailableFilters => new List<string> {"users/created", "users/updated", "users/deleted"};
    }
}