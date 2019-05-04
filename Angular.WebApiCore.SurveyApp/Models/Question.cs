using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Angular.WebApiCore.SurveyApp.Models
{
    public class Question
    {
        public Question()
        {
            this.Choices = new List<Choice>();
        }
        [Key]
        public long QuestionId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }        
    }
}
