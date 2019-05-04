using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.WebApiCore.SurveyApp.Models
{
    public class Answer
    {
        [Key]
        public long AnswerId { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public long QuestionId { get; set; }
        [Required]
        public long ChoiceId { get; set; }
        public User User { get; set; }
        public Question Question { get; set; }
        public Choice Choice { get; set; }        
    }
}
