using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.WebApp.Client.Models.Account
{
    public class Login
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }
    }
}
