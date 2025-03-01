﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSurvey.DataAccessLayer.Entities
{
    [Table("RespondentResult")]
    public class RespondentResult
    {
        [Key]
        [Required]
        [DisplayName("ResponseID")]
        public int ResponseID { get; set; }
        [StringLength(80)]
        [DisplayName("UserName")]
        public string UserName { get; set; }
        [StringLength(30)]
        [DisplayName("Password")]
        public string Password { get; set; }
        [ForeignKey("Questions")]
        [DisplayName("QuestionID")]
        public int QuestionID { get; set; }
        [DisplayName("Question")]
        public string Question { get; set; }
        [DisplayName("ResponseWeight")]
        public int RespondentsWeight { get; set; }
        [DisplayName("ExpectationGap")]
        public decimal ExpectationGap { get; set; }
        [DisplayName("Accuracy")]
        public decimal Accuracy { get; set; }
        [DisplayName("ManagersWeight")]
        public int ManagersWeight { get; set; }
    }
}
