﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OnlineSurvey.DataAccessLayer.Entities
{
    [Table("Question")]
    public class Questions
    {
        [Key]
        [Required]
        [DisplayName("QuestionID")]
        public int QuestionID { get; set; }
        [Required]
        [StringLength(80)]
        [DisplayName("Question")]
        public required string QuestionDescription { get; set; }
    }
}
