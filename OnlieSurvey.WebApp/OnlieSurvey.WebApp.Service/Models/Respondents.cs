using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.WebApp.Service.Models
{
    [Table("Respondent")]
    public class Respondents
    {
        [Key]
        [Required]
        [DisplayName("UserID")]
        public int UserID { get; set; }
        [StringLength(80)]
        [DisplayName("UserName")]
        public required string UserName { get; set; }
        [StringLength(30)]
        [DisplayName("Password")]
        public required string Password { get; set; }        
        [Required]
        [ForeignKey("UserRoles")]
        public int RoleID { get; set; }
        

    }
}