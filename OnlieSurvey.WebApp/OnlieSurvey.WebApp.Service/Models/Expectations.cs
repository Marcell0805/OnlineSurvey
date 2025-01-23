using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.WebApp.Service.Models
{
    [Table("Objective")]
    public class Expectations
    {
        [Key]
        [Required]
        [DisplayName("ObjectiveID")]
        public int ObjectiveID { get; set; }
        [Required]
        [StringLength(80)]
        [DisplayName("FocusArea")]
        public required string FocusArea { get; set; }
        [DisplayName("ExpectedWeight")]
        public int ExpectedWeight { get; set; }
    }
}
