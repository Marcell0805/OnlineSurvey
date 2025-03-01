﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.DataAccessLayer.Entities
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
        public string UserName { get; set; }
        [StringLength(30)]
        [DisplayName("Password")]
        public string Password { get; set; }        
        [Required]
        [ForeignKey("UserRoles")]
        public int RoleID { get; set; }
        

    }
}