using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.WebApp.Service.Models
{
    // UserDetails myDeserializedClass = JsonConvert.DeserializeObject<UserDetails>(myJsonResponse);

    public class UserRoles
    {
        [Key]
        [Required]
        [DisplayName("RoleID")]
        public int RoleID { get; set; }
        [StringLength(30)]
        [DisplayName("RoleName")]
        public required string RoleName { get; set; }
    }


}
