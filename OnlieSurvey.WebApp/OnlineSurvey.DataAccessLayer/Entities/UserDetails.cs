using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.DataAccessLayer.Entities
{
    // UserDetails myDeserializedClass = JsonConvert.DeserializeObject<UserDetails>(myJsonResponse);

    public class UserDetails
    {
        [Key]
        [Required]
        public int userID { get; set; }
        public required string userName { get; set; }
        public required string password { get; set; }
    }


}
