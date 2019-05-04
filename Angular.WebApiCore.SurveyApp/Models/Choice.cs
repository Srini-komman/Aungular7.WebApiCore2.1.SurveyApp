using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Angular.WebApiCore.SurveyApp.Models
{
    public class Choice
    {
        [Key]
        public long ChoiceId { get; set; }
        [Required]
        public long QuestionId { get; set; }
        [Required]
        public string Name { get; set; }
        public Question Question { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
