using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.DataAccessLayer.Entities
{
    public class Respondents
    {
        [Key]
        [Required]
        public int AddressId { get; set; }
        
    }
}